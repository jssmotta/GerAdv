import { IEnderecoSistema } from '../EnderecoSistema/Interfaces/interface.EnderecoSistema';
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
	nometipoenderecosistema?: string;
	nropastaprocessos?: string;
	nomecidade?: string;

}


export function EnderecoSistemaEmpty(): IEnderecoSistema {
// 20250604
    
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
    };
}

export function EnderecoSistemaTestEmpty(): IEnderecoSistema {
// 20250604
    
    return {
        id: 1,
		tipoenderecosistema: 1,
		processo: 1,
		cidade: 1,
		cadastro: 1,
		cadastroexcod: 1,
		motivo: 'X',
		contatonolocal: 'X',
		endereco: 'X',
		bairro: 'X',
		cep: 'X',
		fone: 'X',
		fax: 'X',
		observacao: 'X',
    };
}


