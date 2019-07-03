

results <- read.csv("optymalizacja_funkcji/bin/Debug/meta_results.txt", sep=";", dec=",")[1:5]
names <- names(results)

comp_eq <- matrix(nrow = 5, ncol = 5)

for(i in 1:5){
  for(j in i:5){
    comp_eq[i,j] <- t.test(results[i], results[j])$p.value
    comp_eq[j,i] <- t.test(results[j], results[i])$p.value
  }
}

colnames(comp_eq) <- names
rownames(comp_eq) <- names

comp_gr <- matrix(nrow = 5, ncol = 5)

for(i in 1:5){
  for(j in i:5){
    comp_gr[i,j] <- t.test(results[i], results[j], alternative = "greater")$p.value
    comp_gr[j,i] <- t.test(results[j], results[i], alternative = "greater")$p.value
  }
}

colnames(comp_gr) <- names
rownames(comp_gr) <- names


