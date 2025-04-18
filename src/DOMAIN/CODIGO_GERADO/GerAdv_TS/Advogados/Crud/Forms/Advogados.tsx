﻿"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAdvogados } from '../../Interfaces/interface.Advogados';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import EscritoriosComboBox from '@/app/GerAdv_TS/Escritorios/ComboBox/Escritorios';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import { EscritoriosApi } from '@/app/GerAdv_TS/Escritorios/Apis/ApiEscritorios';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface AdvogadosFormProps {
    advogadosData: IAdvogados;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AdvogadosForm: React.FC<AdvogadosFormProps> = ({
    advogadosData,
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
const [nomeEscritorios, setNomeEscritorios] = useState('');
            const escritoriosApi = new EscritoriosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("cargos") > 0) {
  cargosApi
    .getById(getParamFromUrl("cargos"))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (advogadosData.id === 0) {
    advogadosData.cargo = getParamFromUrl("cargos");
  }
}
 
if (getParamFromUrl("escritorios") > 0) {
  escritoriosApi
    .getById(getParamFromUrl("escritorios"))
    .then((response) => {
      setNomeEscritorios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (advogadosData.id === 0) {
    advogadosData.escritorio = getParamFromUrl("escritorios");
  }
}
 const addValorCargo = (e: any) => {
                        if (e?.id>0)
                        advogadosData.cargo = e.id;
                      };
 const addValorEscritorio = (e: any) => {
                        if (e?.id>0)
                        advogadosData.escritorio = e.id;
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
  {nomeCargos && (<h2>{nomeCargos}</h2>)}
{nomeEscritorios && (<h2>{nomeEscritorios}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={advogadosData.nome}
            onChange={onChange}
            required
          />

            <CargosComboBox
            name={'cargo'}
            value={advogadosData.cargo}
            setValue={addValorCargo}
            label={'Cargos'}
            />

<Input
type="email"
id="emailpro"
label="EMailPro"
className="inputIncNome"
name="emailpro"
value={advogadosData.emailpro}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={advogadosData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={advogadosData.rg}
onChange={onChange}               
/>

<Checkbox label="Casa" name="casa" checked={advogadosData.casa} onChange={onChange} />
        
<Input
type="text"
id="nomemae"
label="NomeMae"
className="inputIncNome"
name="nomemae"
value={advogadosData.nomemae}
onChange={onChange}               
/>

            <EscritoriosComboBox
            name={'escritorio'}
            value={advogadosData.escritorio}
            setValue={addValorEscritorio}
            label={'Escritorios'}
            />

<Checkbox label="Estagiario" name="estagiario" checked={advogadosData.estagiario} onChange={onChange} />
        
<Input
type="text"
id="oab"
label="OAB"
className="inputIncNome"
name="oab"
value={advogadosData.oab}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="nomecompleto"
label="NomeCompleto"
className="inputIncNome"
name="nomecompleto"
value={advogadosData.nomecompleto}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={advogadosData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={advogadosData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={advogadosData.cep}
onChange={onChange}               
/>

<Checkbox label="Sexo" name="sexo" checked={advogadosData.sexo} onChange={onChange} />
        
<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={advogadosData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsserie"
label="CTPSSerie"
className="inputIncNome"
name="ctpsserie"
value={advogadosData.ctpsserie}
onChange={onChange}               
/>

<Input
type="text"
id="ctps"
label="CTPS"
className="inputIncNome"
name="ctps"
value={advogadosData.ctps}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={advogadosData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={advogadosData.fax}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="comissao"
label="Comissao"
className="inputIncNome"
name="comissao"
value={advogadosData.comissao}
onChange={onChange}               
/>

<Input
type="text"
id="dtinicio"
label="DtInicio"
className="inputIncNome"
name="dtinicio"
value={advogadosData.dtinicio}
onChange={onChange}               
/>

<Input
type="text"
id="dtfim"
label="DtFim"
className="inputIncNome"
name="dtfim"
value={advogadosData.dtfim}
onChange={onChange}               
/>

<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={advogadosData.dtnasc}
onChange={onChange}               
/>

<Input
type="text"
id="salario"
label="Salario"
className="inputIncNome"
name="salario"
value={advogadosData.salario}
onChange={onChange}               
/>

<Input
type="text"
id="secretaria"
label="Secretaria"
className="inputIncNome"
name="secretaria"
value={advogadosData.secretaria}
onChange={onChange}               
/>

<Input
type="text"
id="textoprocuracao"
label="TextoProcuracao"
className="inputIncNome"
name="textoprocuracao"
value={advogadosData.textoprocuracao}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={advogadosData.email}
onChange={onChange}               
/>

<Input
type="text"
id="especializacao"
label="Especializacao"
className="inputIncNome"
name="especializacao"
value={advogadosData.especializacao}
onChange={onChange}               
/>

<Input
type="text"
id="pasta"
label="Pasta"
className="inputIncNome"
name="pasta"
value={advogadosData.pasta}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={advogadosData.observacao}
onChange={onChange}               
/>

<Input
type="text"
id="contabancaria"
label="ContaBancaria"
className="inputIncNome"
name="contabancaria"
value={advogadosData.contabancaria}
onChange={onChange}               
/>

<Checkbox label="ParcTop" name="parctop" checked={advogadosData.parctop} onChange={onChange} />
        
<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={advogadosData.class}
onChange={onChange}               
/>

<Checkbox label="Top" name="top" checked={advogadosData.top} onChange={onChange} />
<Checkbox label="Ani" name="ani" checked={advogadosData.ani} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendaquem${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Agenda Quem</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarepetir${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Agenda Repetir</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contratos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Contratos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/horastrab${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Horas Trab</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/parceriaproc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Parceria Proc</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Processos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/proprocuradores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Pro Procuradores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendasemana${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?advogados=${advogadosData.id}`)}>Agenda Semana</div>

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
 