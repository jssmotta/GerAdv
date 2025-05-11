// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOutrasPartesCliente } from '@/app/GerAdv_TS/OutrasPartesCliente/Interfaces/interface.OutrasPartesCliente';
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

import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCep from '@/app/components/Inputs/InputCep'

interface OutrasPartesClienteFormProps {
    outraspartesclienteData: IOutrasPartesCliente;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OutrasPartesClienteForm: React.FC<OutrasPartesClienteFormProps> = ({
    outraspartesclienteData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
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
        console.error("Erro ao submeter formulário de OutrasPartesCliente:", error);
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
          target: document.getElementById(`OutrasPartesClienteForm-${outraspartesclienteData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar OutrasPartesCliente diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-OutrasPartesCliente' : 'form-container form-container-OutrasPartesCliente'}>
       
            <form className='formInputCadInc' id={`OutrasPartesClienteForm-${outraspartesclienteData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={outraspartesclienteData} isSubmitting={isSubmitting} onClose={onClose} formId={`OutrasPartesClienteForm-${outraspartesclienteData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={outraspartesclienteData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

                <InputCheckbox label="Terceirizado" name="terceirizado" checked={outraspartesclienteData.terceirizado} onChange={onChange} />
        
<InputInput
type="text"
id="clienteprincipal"
label="ClientePrincipal"
className="inputIncNome"
name="clienteprincipal"
value={outraspartesclienteData.clienteprincipal}
onChange={onChange}               
/>

<InputCheckbox label="Tipo" name="tipo" checked={outraspartesclienteData.tipo} onChange={onChange} />
<InputCheckbox label="Sexo" name="sexo" checked={outraspartesclienteData.sexo} onChange={onChange} />
        
<InputInput
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={outraspartesclienteData.dtnasc}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={outraspartesclienteData.cpf}
onChange={onChange}               
/>

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={outraspartesclienteData.rg}
onChange={onChange}               
/>

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={outraspartesclienteData.cnpj}
onChange={onChange}               
/>

<InputInput
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={outraspartesclienteData.inscest}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="nomefantasia"
label="NomeFantasia"
className="inputIncNome"
name="nomefantasia"
value={outraspartesclienteData.nomefantasia}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={outraspartesclienteData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={outraspartesclienteData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={outraspartesclienteData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={outraspartesclienteData.bairro}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={outraspartesclienteData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={outraspartesclienteData.fax}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={outraspartesclienteData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={outraspartesclienteData.site}
onChange={onChange}               
/>

<InputInput
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={outraspartesclienteData.class}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Ani" name="ani" checked={outraspartesclienteData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 