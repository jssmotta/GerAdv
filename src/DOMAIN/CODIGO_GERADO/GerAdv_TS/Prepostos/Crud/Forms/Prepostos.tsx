﻿"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IPrepostos } from '../../Interfaces/interface.Prepostos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import FuncaoComboBox from '@/app/GerAdv_TS/Funcao/ComboBox/Funcao';
import SetorComboBox from '@/app/GerAdv_TS/Setor/ComboBox/Setor';
import { FuncaoApi } from '@/app/GerAdv_TS/Funcao/Apis/ApiFuncao';
import { SetorApi } from '@/app/GerAdv_TS/Setor/Apis/ApiSetor';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface PrepostosFormProps {
    prepostosData: IPrepostos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PrepostosForm: React.FC<PrepostosFormProps> = ({
    prepostosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeFuncao, setNomeFuncao] = useState('');
            const funcaoApi = new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeSetor, setNomeSetor] = useState('');
            const setorApi = new SetorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("funcao") > 0) {
  funcaoApi
    .getById(getParamFromUrl("funcao"))
    .then((response) => {
      setNomeFuncao(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prepostosData.id === 0) {
    prepostosData.funcao = getParamFromUrl("funcao");
  }
}
 
if (getParamFromUrl("setor") > 0) {
  setorApi
    .getById(getParamFromUrl("setor"))
    .then((response) => {
      setNomeSetor(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prepostosData.id === 0) {
    prepostosData.setor = getParamFromUrl("setor");
  }
}
 const addValorFuncao = (e: any) => {
                        if (e?.id>0)
                        prepostosData.funcao = e.id;
                      };
 const addValorSetor = (e: any) => {
                        if (e?.id>0)
                        prepostosData.setor = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeFuncao && (<h2>{nomeFuncao}</h2>)}
{nomeSetor && (<h2>{nomeSetor}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={prepostosData.nome}
            onChange={onChange}
            required
          />

            <FuncaoComboBox
            name={'funcao'}
            value={prepostosData.funcao}
            setValue={addValorFuncao}
            label={'Função'}
            />

            <SetorComboBox
            name={'setor'}
            value={prepostosData.setor}
            setValue={addValorSetor}
            label={'Setor'}
            />

<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={prepostosData.dtnasc}
onChange={onChange}               
/>

<Input
type="text"
id="qualificacao"
label="Qualificacao"
className="inputIncNome"
name="qualificacao"
value={prepostosData.qualificacao}
onChange={onChange}               
/>

<Checkbox label="Sexo" name="sexo" checked={prepostosData.sexo} onChange={onChange} />
        
<Input
type="text"
id="idade"
label="Idade"
className="inputIncNome"
name="idade"
value={prepostosData.idade}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={prepostosData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={prepostosData.rg}
onChange={onChange}               
/>

<Input
type="text"
id="periodo_ini"
label="Periodo_Ini"
className="inputIncNome"
name="periodo_ini"
value={prepostosData.periodo_ini}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="periodo_fim"
label="Periodo_Fim"
className="inputIncNome"
name="periodo_fim"
value={prepostosData.periodo_fim}
onChange={onChange}               
/>

<Input
type="text"
id="registro"
label="Registro"
className="inputIncNome"
name="registro"
value={prepostosData.registro}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsnumero"
label="CTPSNumero"
className="inputIncNome"
name="ctpsnumero"
value={prepostosData.ctpsnumero}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsserie"
label="CTPSSerie"
className="inputIncNome"
name="ctpsserie"
value={prepostosData.ctpsserie}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsdtemissao"
label="CTPSDtEmissao"
className="inputIncNome"
name="ctpsdtemissao"
value={prepostosData.ctpsdtemissao}
onChange={onChange}               
/>

<Input
type="text"
id="pis"
label="PIS"
className="inputIncNome"
name="pis"
value={prepostosData.pis}
onChange={onChange}               
/>

<Input
type="text"
id="salario"
label="Salario"
className="inputIncNome"
name="salario"
value={prepostosData.salario}
onChange={onChange}               
/>

<Checkbox label="LiberaAgenda" name="liberaagenda" checked={prepostosData.liberaagenda} onChange={onChange} />
        
<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={prepostosData.observacao}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={prepostosData.endereco}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={prepostosData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={prepostosData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={prepostosData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={prepostosData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={prepostosData.fax}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={prepostosData.email}
onChange={onChange}               
/>

<Input
type="text"
id="pai"
label="Pai"
className="inputIncNome"
name="pai"
value={prepostosData.pai}
onChange={onChange}               
/>

<Input
type="text"
id="mae"
label="Mae"
className="inputIncNome"
name="mae"
value={prepostosData.mae}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={prepostosData.class}
onChange={onChange}               
/>

<Checkbox label="Ani" name="ani" checked={prepostosData.ani} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?prepostos=${prepostosData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?prepostos=${prepostosData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendaquem${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?prepostos=${prepostosData.id}`)}>Agenda Quem</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?prepostos=${prepostosData.id}`)}>Processos</div>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 