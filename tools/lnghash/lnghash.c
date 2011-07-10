#include <stdio.h>

int main(int argc, char *argv[]) {
	if (argc < 5) {
		printf("Usage: %s <buckets> <seed> <multiplier> <lng_key>\nNote: The first 3 values correspond to the values in the HSHT section, respectively\n", argv[1]);
		return 1;
	}
	int var1 = atoi(argv[1]);
	int var2 = atoi(argv[2]);
	int var3 = atoi(argv[3]);
	char *ptr = argv[4];
	unsigned int i;

	i = var2;
	while (*ptr) {
		i = (i * var3) + *ptr;
		ptr++;
	}
	printf("%u\n", i % var1);
	return 0;
}
