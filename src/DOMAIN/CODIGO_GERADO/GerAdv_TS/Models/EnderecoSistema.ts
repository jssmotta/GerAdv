import { Auditor } from "./Auditor";

import { IEnderecoSistema } from "../EnderecoSistema/Interfaces/interface.EnderecoSistema";
export interface EnderecoSistema
{
    id: number;
	tipoenderecosistema : number;
	processo : number;
	cidade : number;
	cadastro : number;
	cadastroexcod : number;
	motivo : string;
	contatonolocal : string;
	endereco : string;
	bairro : string;
	cep : string;
	fone : string;
	fax : string;
	observacao : string;
	auditor?: Auditor | null;
}

export function EnderecoSistemaEmpty(): IEnderecoSistema {
// 20250125
    return {
        id: 0,
		tipoenderecosistema: 0,
		processo: 0,
		cidade: 0,
		cadastro: 0,
		cadastroexcod: 0,
		motivo: '',
		contatonolocal: '',
		endereco: '',
		bairro: '',
		cep: '',
		fone: '',
		fax: '',
		observacao: '',
		auditor: null
    };
}
