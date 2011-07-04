// This program will decode the header for some .nfs files
//
// Only tested so far on DiRT3 speech audio files
// Definitely doesn't do anything for some other nfs files (such as the DLC ones)
// Patches to clean up the decode routine are very welcome!

#include <stdio.h>
#include <malloc.h>

#define uint unsigned int

int check(char *buf) {
	if (!buf) return 0;
	if ((*(uint *)(buf + 0) ^ *(uint *)(buf + 48)) != 0x5346654E) {
		printf("Bad magic\n");
		return 0; // "NeFS"
	}
	if ((*(uint *)(buf + 8) ^ *(uint *)(buf + 16)) != 0x010501) {
		printf("Bad version\n");
		return 0;
	}
	return 1;
}


int decode(char *buf) {
	if (!check(buf)) return 0;

	int v2;
	char *v3;
	int v4;
	int v5;
	int v6;
	int v7;
	int v8;
	int v9;
	int v10;
	int v11;
	int v12;
	int v13;
	int v14;
	int v15;
	int v16;
	int v17;
	int v18;
	int v19;
	int v20;
	int v21;
	int v22;
	int v23;
	int v24;
	int v25;
	int v26;
	int v27;
	int v28;
	int v29;

	v4 = *(uint *)(buf + 8);
	v5 = *(uint *)(buf + 20);
	*(uint *)(buf + 56) ^= v5;
	v6 = v5 ^ v4;
	v7 = *(uint *)(buf + 16);
	*(uint *)(buf + 20) = v6;
	v8 = v4 ^ v7;
	v9 = *(uint *)(buf + 28);
	v4 = *(uint *)(buf + 8);
	v5 = *(uint *)(buf + 20);
	*(uint *)(buf + 56) ^= v5;
	v6 = v5 ^ v4;
	v7 = *(uint *)(buf + 16);
	*(uint *)(buf + 20) = v6;
	v8 = v4 ^ v7;
	v9 = *(uint *)(buf + 28);
	*(uint *)(buf + 8) = v8;
	v10 = v7 ^ v9;
	v11 = *(uint *)(buf + 12);
	*(uint *)(buf + 16) = v10;
	v12 = v9 ^ v11;
	v13 = *(uint *)(buf + 36);
	*(uint *)(buf + 28) = v12;
	v14 = v11 ^ v13;
	v15 = *(uint *)(buf + 40);
	*(uint *)(buf + 12) = v14;
	v16 = v13 ^ v15;
	v17 = *(uint *)(buf + 4);
	*(uint *)(buf + 36) = v16;
	v18 = v15 ^ v17;
	v19 = *(uint *)(buf + 52);
	*(uint *)(buf + 40) = v18;
	v20 = v17 ^ v19;
	v21 = *(uint *)(buf + 44);
	*(uint *)(buf + 4) = v20;
	v22 = v19 ^ v21;
	v23 = *(uint *)buf;
	*(uint *)(buf + 52) = v22;
	v24 = v21 ^ v23;
	v25 = *(uint *)(buf + 48);
	*(uint *)(buf + 44) = v24;
	v26 = v23 ^ v25;
	v27 = *(uint *)(buf + 24);
	*(uint *)buf = v26;
	v28 = v25 ^ v27;
	v29 = *(uint *)(buf + 32);
	*(uint *)(buf + 48) = v28;
	*(uint *)(buf + 32) = v29 ^ *(uint *)(buf + 56);
	*(uint *)(buf + 24) = v27 ^ v29;

	v3 = buf + 68;
	v2 = 4;
	do {
		*(uint *)(v3 - 8) ^= *(uint *)(buf + 56);
		*(uint *)(v3 - 4) ^= *(uint *)(buf + 56);
		*(uint *)v3 ^= *(uint *)(buf + 56);
		*(uint *)(v3 + 4) ^= *(uint *)(buf + 56);
		v3 += 16;
		v2--;
	} while (v2);
	return 1;
}

int main(int argc, char *argv[]) {
	FILE *in, *out;
	char *buf;
	long size;

	if (argc < 3) {
		printf("Usage: %s <input> <output>\n", argv[0]);
		return;
	}

	in = fopen(argv[1], "rb");
	if (in == NULL) {
		printf("Could not open input file\n");
		return 1;
	}

	out = fopen(argv[2], "wb");
	if (out == NULL) {
		printf("Could not open output file\n");
		return 1;
	}

	fseek(in, 0, SEEK_END);
	size = ftell(in);
	rewind(in);

	buf = (char*)malloc(sizeof(char)*size);
	if (fread(buf, 1, size, in) != size) {
		printf("Read error\n");
		return 2;
	}

	fclose(in);

	if (!decode(buf)) {
		printf("Not a valid nfs file\n");
		return 3;
	}

	fwrite(buf, 1, size, out);
	fclose(out);
	free(buf);
	return 1;
}
