import { Auditor } from "../../Models/Auditor";

export interface IGruposEmpresas {
  id: number;
	oponente : number;
	cliente : number;
	email : string;
	inativo : boolean;
	descricao : string;
	observacoes : string;
	icone : string;
	despesaunificada : boolean;
	guid : string;
	auditor?: Auditor | null;
}
