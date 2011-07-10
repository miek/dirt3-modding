Language hash table pseudocode
==============================

<code>
int HSHS[3];
int HSHT[];
int SIDA[];
char *SIDB[];
char *LNGB[];

char *lookup(char *key) {
	int hsht_val, hsht_next;
	unsigned int hash = lnghash(key);

	hsht_val = HSHT[hash*2];
	hsht_next = HSHT[hash*2 + 1];

	if (hsht_next == 0) return 0;
	int i = 0;
	while (1) {
		if (!strcmp(SIDB[SIDA[(i + hsht_val)*2]], key)) {
			break;
		}
		i++;
		if (i >= hsht_next) {
			return 0;
		}
	}
	return LNGB[SIDA[(i + hsht_val)*2 + 1]];
}
</code>
