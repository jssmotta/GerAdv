// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IContatoCRMOperador } from '@/app/GerAdv_TS/ContatoCRMOperador/Interfaces/interface.ContatoCRMOperador';
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

import ContatoCRMComboBox from '@/app/GerAdv_TS/ContatoCRM/ComboBox/ContatoCRM';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { ContatoCRMApi } from '@/app/GerAdv_TS/ContatoCRM/Apis/ApiContatoCRM';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface ContatoCRMOperadorFormProps {
    contatocrmoperadorData: IContatoCRMOperador;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ContatoCRMOperadorForm: React.FC<ContatoCRMOperadorFormProps> = ({
    contatocrmoperadorData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeContatoCRM, setNomeContatoCRM] = useState('');
            const contatocrmApi = new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("contatocrm") > 0) {
  contatocrmApi
    .getById(getParamFromUrl("contatocrm"))
    .then((response) => {
      setNomeContatoCRM(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmoperadorData.id === 0) {
    contatocrmoperadorData.contatocrm = getParamFromUrl("contatocrm");
  }
}
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmoperadorData.id === 0) {
    contatocrmoperadorData.operador = getParamFromUrl("operador");
  }
}
 const addValorContatoCRM = (e: any) => {
                        if (e?.id>0)
                        contatocrmoperadorData.contatocrm = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        contatocrmoperadorData.operador = e.id;
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
        console.error("Erro ao submeter formulário de ContatoCRMOperador:", error);
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
          target: document.getElementById(`ContatoCRMOperadorForm-${contatocrmoperadorData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ContatoCRMOperador diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ContatoCRMOperador' : 'form-container5 form-container-ContatoCRMOperador'}>
       
            <form className='formInputCadInc' id={`ContatoCRMOperadorForm-${contatocrmoperadorData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={contatocrmoperadorData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMOperadorForm-${contatocrmoperadorData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ContatoCRMComboBox
            name={'contatocrm'}
            value={contatocrmoperadorData.contatocrm}
            setValue={addValorContatoCRM}
            label={'Contato C R M'}
            />

<InputInput
type="text"
id="cargoesc"
label="CargoEsc"
className="inputIncNome"
name="cargoesc"
value={contatocrmoperadorData.cargoesc}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={contatocrmoperadorData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 