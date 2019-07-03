

results_TSP <- read.csv("optymalizacja_funkcji/bin/Debug/TSP_results.txt", sep=";", dec=",")[1:5]
names_TSP <- names(results_TSP)

comp_eq_TSP <- matrix(nrow = 5, ncol = 5)

for(i in 1:5){
  for(j in i:5){
    comp_eq_TSP[i,j] <- t.test(results[i], results[j])$p.value
    comp_eq_TSP[j,i] <- t.test(results[j], results[i])$p.value
  }
}

colnames(comp_eq_TSP) <- names_TSP
rownames(comp_eq_TSP) <- names_TSP

comp_gr_TSP <- matrix(nrow = 5, ncol = 5)

for(i in 1:5){
  for(j in i:5){
    comp_gr_TSP[i,j] <- t.test(results_TSP[i], results_TSP[j], alternative = "less")$p.value
    comp_gr_TSP[j,i] <- t.test(results_TSP[j], results_TSP[i], alternative = "less")$p.value
  }
}

colnames(comp_gr_TSP) <- names_TSP
rownames(comp_gr_TSP) <- names_TSP

summary(results_TSP)
