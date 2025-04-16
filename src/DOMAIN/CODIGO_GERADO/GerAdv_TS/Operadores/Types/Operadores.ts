import { Auditor } from "../../Models/Auditor";

export interface IOperadores {
  id: number;
	cliente : number;
	enviado : boolean;
	casa : boolean;
	casaid : number;
	casacodigo : number;
	isnovo : boolean;
	grupo : number;
	nome : string;
	email : string;
	senha : string;
	ativado : boolean;
	atualizarsenha : boolean;
	senha256 : string;
	suportesenha256 : string;
	suportemaxage : string;
	auditor?: Auditor | null;
}
