// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IColaboradores } from '@/app/GerAdv_TS/Colaboradores/Interfaces/interface.Colaboradores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'

interface ColaboradoresFormProps {
    colaboradoresData: IColaboradores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ColaboradoresForm: React.FC<ColaboradoresFormProps> = ({
    colaboradoresData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeCargos, setNomeCargos] = useState('');
            const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("cargos") > 0) {
  cargosApi
    .getById(getParamFromUrl("cargos"))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (colaboradoresData.id === 0) {
    colaboradoresData.cargo = getParamFromUrl("cargos");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (colaboradoresData.id === 0) {
    colaboradoresData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCargo = (e: any) => {
                        if (e?.id>0)
                        colaboradoresData.cargo = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        colaboradoresData.cliente = e.id;
                      };

    const onConfirm = (e: React.FormEvent) => {
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de Colaboradores:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`ColaboradoresForm-${colaboradoresData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Colaboradores diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Colaboradores' : 'form-container form-container-Colaboradores'}>
       
            <form className='formInputCadInc' id={`ColaboradoresForm-${colaboradoresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={colaboradoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`ColaboradoresForm-${colaboradoresData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={colaboradoresData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <CargosComboBox
            name={'cargo'}
            value={colaboradoresData.cargo}
            setValue={addValorCargo}
            label={'Cargos'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={colaboradoresData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputCheckbox label="Sexo" name="sexo" checked={colaboradoresData.sexo} onChange={onChange} />
        
<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={colaboradoresData.cpf}
onChange={onChange}               
/>

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={colaboradoresData.rg}
onChange={onChange}               
/>

<InputInput
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={colaboradoresData.dtnasc}
onChange={onChange}               
/>

<InputInput
type="text"
id="idade"
label="Idade"
className="inputIncNome"
name="idade"
value={colaboradoresData.idade}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={colaboradoresData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={colaboradoresData.bairro}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={colaboradoresData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={colaboradoresData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={colaboradoresData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={colaboradoresData.observacao}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={colaboradoresData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="cnh"
label="CNH"
className="inputIncNome"
name="cnh"
value={colaboradoresData.cnh}
onChange={onChange}               
/>

<InputInput
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={colaboradoresData.class}
onChange={onChange}               
/>

<InputCheckbox label="Ani" name="ani" checked={colaboradoresData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 