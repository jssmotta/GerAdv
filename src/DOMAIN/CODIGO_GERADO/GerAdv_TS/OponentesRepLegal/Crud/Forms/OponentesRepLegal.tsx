// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOponentesRepLegal } from '@/app/GerAdv_TS/OponentesRepLegal/Interfaces/interface.OponentesRepLegal';
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

import OponentesComboBox from '@/app/GerAdv_TS/Oponentes/ComboBox/Oponentes';
import { OponentesApi } from '@/app/GerAdv_TS/Oponentes/Apis/ApiOponentes';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface OponentesRepLegalFormProps {
    oponentesreplegalData: IOponentesRepLegal;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OponentesRepLegalForm: React.FC<OponentesRepLegalFormProps> = ({
    oponentesreplegalData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOponentes, setNomeOponentes] = useState('');
            const oponentesApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("oponentes") > 0) {
  oponentesApi
    .getById(getParamFromUrl("oponentes"))
    .then((response) => {
      setNomeOponentes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (oponentesreplegalData.id === 0) {
    oponentesreplegalData.oponente = getParamFromUrl("oponentes");
  }
}
 const addValorOponente = (e: any) => {
                        if (e?.id>0)
                        oponentesreplegalData.oponente = e.id;
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
        console.error("Erro ao submeter formulário de OponentesRepLegal:", error);
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
          target: document.getElementById(`OponentesRepLegalForm-${oponentesreplegalData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar OponentesRepLegal diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-OponentesRepLegal' : 'form-container form-container-OponentesRepLegal'}>
       
            <form className='formInputCadInc' id={`OponentesRepLegalForm-${oponentesreplegalData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={oponentesreplegalData} isSubmitting={isSubmitting} onClose={onClose} formId={`OponentesRepLegalForm-${oponentesreplegalData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={oponentesreplegalData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={oponentesreplegalData.fone}
onChange={onChange}               
/>

            <OponentesComboBox
            name={'oponente'}
            value={oponentesreplegalData.oponente}
            setValue={addValorOponente}
            label={'Oponentes'}
            />

<InputCheckbox label="Sexo" name="sexo" checked={oponentesreplegalData.sexo} onChange={onChange} />
        
<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={oponentesreplegalData.cpf}
onChange={onChange}               
/>

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={oponentesreplegalData.rg}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={oponentesreplegalData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={oponentesreplegalData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={oponentesreplegalData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={oponentesreplegalData.cidade}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={oponentesreplegalData.fax}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={oponentesreplegalData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={oponentesreplegalData.site}
onChange={onChange}               
/>

<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={oponentesreplegalData.observacao}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 