Language hash table pseudocode
==============================

	int HSHS[3];
	HSHT_Entry HSHT[];
	SIDA_Entry SIDA[];
	char *SIDB;
	char *LNGB;
	
	char *lookup(char *key) {
		int bucket, count;
		unsigned int hash = lnghash(key);
	
		bucket = HSHT[hash].bucket;
		count = HSHT[hash].count;
	
		if (count == 0) return 0;
		int i = 0;
		while (1) {
			if (!strcmp(SIDB[SIDA[bucket + i].sidb_offset], key)) {
				break;
			}
			i++;
			if (i >= count) {
				return 0;
			}
		}
		return LNGB[SIDA[bucket + i].lngb_offset];
	}
