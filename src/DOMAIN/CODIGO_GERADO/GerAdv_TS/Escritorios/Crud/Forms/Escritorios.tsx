// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IEscritorios } from '@/app/GerAdv_TS/Escritorios/Interfaces/interface.Escritorios';
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
import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'

interface EscritoriosFormProps {
    escritoriosData: IEscritorios;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const EscritoriosForm: React.FC<EscritoriosFormProps> = ({
    escritoriosData,
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
        console.error("Erro ao submeter formulário de Escritorios:", error);
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
          target: document.getElementById(`EscritoriosForm-${escritoriosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Escritorios diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Escritorios' : 'form-container form-container-Escritorios'}>
       
            <form className='formInputCadInc' id={`EscritoriosForm-${escritoriosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={escritoriosData} isSubmitting={isSubmitting} onClose={onClose} formId={`EscritoriosForm-${escritoriosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={escritoriosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={escritoriosData.cnpj}
onChange={onChange}               
/>

<InputCheckbox label="Casa" name="casa" checked={escritoriosData.casa} onChange={onChange} />
<InputCheckbox label="Parceria" name="parceria" checked={escritoriosData.parceria} onChange={onChange} />
        
<InputInput
type="text"
id="oab"
label="OAB"
className="inputIncNome"
name="oab"
value={escritoriosData.oab}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={escritoriosData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={escritoriosData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={escritoriosData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={escritoriosData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={escritoriosData.fone}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={escritoriosData.fax}
onChange={onChange}               
/>

<InputInput
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={escritoriosData.site}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={escritoriosData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={escritoriosData.obs}
onChange={onChange}               
/>

<InputInput
type="text"
id="advresponsavel"
label="AdvResponsavel"
className="inputIncNome"
name="advresponsavel"
value={escritoriosData.advresponsavel}
onChange={onChange}               
/>

<InputInput
type="text"
id="secretaria"
label="Secretaria"
className="inputIncNome"
name="secretaria"
value={escritoriosData.secretaria}
onChange={onChange}               
/>

<InputInput
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={escritoriosData.inscest}
onChange={onChange}               
/>

<InputCheckbox label="Correspondente" name="correspondente" checked={escritoriosData.correspondente} onChange={onChange} />
<InputCheckbox label="Top" name="top" checked={escritoriosData.top} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 