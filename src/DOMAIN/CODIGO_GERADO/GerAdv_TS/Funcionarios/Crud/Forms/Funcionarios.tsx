// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IFuncionarios } from '@/app/GerAdv_TS/Funcionarios/Interfaces/interface.Funcionarios';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import FuncaoComboBox from '@/app/GerAdv_TS/Funcao/ComboBox/Funcao';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import { FuncaoApi } from '@/app/GerAdv_TS/Funcao/Apis/ApiFuncao';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface FuncionariosFormProps {
    funcionariosData: IFuncionarios;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const FuncionariosForm: React.FC<FuncionariosFormProps> = ({
    funcionariosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeCargos, setNomeCargos] = useState('');
            const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncao, setNomeFuncao] = useState('');
            const funcaoApi = new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("cargos") > 0) {
  cargosApi
    .getById(getParamFromUrl("cargos"))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (funcionariosData.id === 0) {
    funcionariosData.cargo = getParamFromUrl("cargos");
  }
}
 
if (getParamFromUrl("funcao") > 0) {
  funcaoApi
    .getById(getParamFromUrl("funcao"))
    .then((response) => {
      setNomeFuncao(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (funcionariosData.id === 0) {
    funcionariosData.funcao = getParamFromUrl("funcao");
  }
}
 const addValorCargo = (e: any) => {
                        if (e?.id>0)
                        funcionariosData.cargo = e.id;
                      };
 const addValorFuncao = (e: any) => {
                        if (e?.id>0)
                        funcionariosData.funcao = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('FuncionariosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`FuncionariosForm-${funcionariosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={funcionariosData} isSubmitting={isSubmitting} onClose={onClose} formId={`FuncionariosForm-${funcionariosData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={funcionariosData.nome}
            placeholder={`Digite nome colaborador`}
            onChange={onChange}
            required
          />

<Input
type="email"
id="emailpro"
label="EMailPro"
className="inputIncNome"
name="emailpro"
value={funcionariosData.emailpro}
onChange={onChange}               
/>

            <CargosComboBox
            name={'cargo'}
            value={funcionariosData.cargo}
            setValue={addValorCargo}
            label={'Cargos'}
            />

            <FuncaoComboBox
            name={'funcao'}
            value={funcionariosData.funcao}
            setValue={addValorFuncao}
            label={'Função'}
            />

<InputCheckbox label="Sexo" name="sexo" checked={funcionariosData.sexo} onChange={onChange} />
        
<Input
type="text"
id="registro"
label="Registro"
className="inputIncNome"
name="registro"
value={funcionariosData.registro}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={funcionariosData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={funcionariosData.rg}
onChange={onChange}               
/>

<InputCheckbox label="Tipo" name="tipo" checked={funcionariosData.tipo} onChange={onChange} />
        
<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={funcionariosData.observacao}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={funcionariosData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={funcionariosData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={funcionariosData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={funcionariosData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={funcionariosData.contato}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={funcionariosData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={funcionariosData.fone}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={funcionariosData.email}
onChange={onChange}               
/>

<Input
type="text"
id="periodo_ini"
label="Periodo_Ini"
className="inputIncNome"
name="periodo_ini"
value={funcionariosData.periodo_ini}
onChange={onChange}               
/>

<Input
type="text"
id="periodo_fim"
label="Periodo_Fim"
className="inputIncNome"
name="periodo_fim"
value={funcionariosData.periodo_fim}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="ctpsnumero"
label="CTPSNumero"
className="inputIncNome"
name="ctpsnumero"
value={funcionariosData.ctpsnumero}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsserie"
label="CTPSSerie"
className="inputIncNome"
name="ctpsserie"
value={funcionariosData.ctpsserie}
onChange={onChange}               
/>

<Input
type="text"
id="pis"
label="PIS"
className="inputIncNome"
name="pis"
value={funcionariosData.pis}
onChange={onChange}               
/>

<Input
type="text"
id="salario"
label="Salario"
className="inputIncNome"
name="salario"
value={funcionariosData.salario}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsdtemissao"
label="CTPSDtEmissao"
className="inputIncNome"
name="ctpsdtemissao"
value={funcionariosData.ctpsdtemissao}
onChange={onChange}               
/>

<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={funcionariosData.dtnasc}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={funcionariosData.data}
onChange={onChange}               
/>

<InputCheckbox label="LiberaAgenda" name="liberaagenda" checked={funcionariosData.liberaagenda} onChange={onChange} />
        
<Input
type="text"
id="pasta"
label="Pasta"
className="inputIncNome"
name="pasta"
value={funcionariosData.pasta}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={funcionariosData.class}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Ani" name="ani" checked={funcionariosData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 