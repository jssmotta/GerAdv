// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IEnderecos } from '@/app/GerAdv_TS/Enderecos/Interfaces/interface.Enderecos';
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

import InputDescription from '@/app/components/Inputs/InputDescription';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'

interface EnderecosFormProps {
    enderecosData: IEnderecos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const EnderecosForm: React.FC<EnderecosFormProps> = ({
    enderecosData,
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
        console.error("Erro ao submeter formulário de Enderecos:", error);
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
          target: document.getElementById(`EnderecosForm-${enderecosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Enderecos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Enderecos' : 'form-container form-container-Enderecos'}>
       
            <form className='formInputCadInc' id={`EnderecosForm-${enderecosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={enderecosData} isSubmitting={isSubmitting} onClose={onClose} formId={`EnderecosForm-${enderecosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="endereço"
            className="inputIncNome"
            name="descricao"
            value={enderecosData.descricao}
            placeholder={`Digite nome endereço`}
            onChange={onChange}
            required
            disabled={enderecosData.id > 0}
          />

                <InputCheckbox label="TopIndex" name="topindex" checked={enderecosData.topindex} onChange={onChange} />
        
<InputInput
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={enderecosData.contato}
onChange={onChange}               
/>

<InputInput
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={enderecosData.dtnasc}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={enderecosData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={enderecosData.bairro}
onChange={onChange}               
/>

<InputCheckbox label="Privativo" name="privativo" checked={enderecosData.privativo} onChange={onChange} />
<InputCheckbox label="AddContato" name="addcontato" checked={enderecosData.addcontato} onChange={onChange} />
        
<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={enderecosData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="oab"
label="OAB"
className="inputIncNome"
name="oab"
value={enderecosData.oab}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={enderecosData.obs}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={enderecosData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={enderecosData.fax}
onChange={onChange}               
/>

<InputInput
type="text"
id="tratamento"
label="Tratamento"
className="inputIncNome"
name="tratamento"
value={enderecosData.tratamento}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={enderecosData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={enderecosData.site}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={enderecosData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="quem"
label="Quem"
className="inputIncNome"
name="quem"
value={enderecosData.quem}
onChange={onChange}               
/>

<InputInput
type="text"
id="quemindicou"
label="QuemIndicou"
className="inputIncNome"
name="quemindicou"
value={enderecosData.quemindicou}
onChange={onChange}               
/>

<InputCheckbox label="ReportECBOnly" name="reportecbonly" checked={enderecosData.reportecbonly} onChange={onChange} />
</div><div className="grid-container"><InputCheckbox label="Ani" name="ani" checked={enderecosData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 