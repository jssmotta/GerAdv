// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITribEnderecos } from '@/app/GerAdv_TS/TribEnderecos/Interfaces/interface.TribEnderecos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import TribunalComboBox from '@/app/GerAdv_TS/Tribunal/ComboBox/Tribunal';
import { TribunalApi } from '@/app/GerAdv_TS/Tribunal/Apis/ApiTribunal';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'

interface TribEnderecosFormProps {
    tribenderecosData: ITribEnderecos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TribEnderecosForm: React.FC<TribEnderecosFormProps> = ({
    tribenderecosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTribunal, setNomeTribunal] = useState('');
            const tribunalApi = new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tribunal") > 0) {
  tribunalApi
    .getById(getParamFromUrl("tribunal"))
    .then((response) => {
      setNomeTribunal(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (tribenderecosData.id === 0) {
    tribenderecosData.tribunal = getParamFromUrl("tribunal");
  }
}
 const addValorTribunal = (e: any) => {
                        if (e?.id>0)
                        tribenderecosData.tribunal = e.id;
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
        console.error("Erro ao submeter formulário de TribEnderecos:", error);
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
          target: document.getElementById(`TribEnderecosForm-${tribenderecosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar TribEnderecos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-TribEnderecos' : 'form-container5 form-container-TribEnderecos'}>
       
            <form className='formInputCadInc' id={`TribEnderecosForm-${tribenderecosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tribenderecosData} isSubmitting={isSubmitting} onClose={onClose} formId={`TribEnderecosForm-${tribenderecosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <TribunalComboBox
            name={'tribunal'}
            value={tribenderecosData.tribunal}
            setValue={addValorTribunal}
            label={'Tribunal'}
            />

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={tribenderecosData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={tribenderecosData.endereco}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={tribenderecosData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={tribenderecosData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={tribenderecosData.fax}
onChange={onChange}               
/>

<InputInput
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={tribenderecosData.obs}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 