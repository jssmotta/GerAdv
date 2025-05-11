// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { INECompromissos } from '@/app/GerAdv_TS/NECompromissos/Interfaces/interface.NECompromissos';
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

import TipoCompromissoComboBox from '@/app/GerAdv_TS/TipoCompromisso/ComboBox/TipoCompromisso';
import { TipoCompromissoApi } from '@/app/GerAdv_TS/TipoCompromisso/Apis/ApiTipoCompromisso';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface NECompromissosFormProps {
    necompromissosData: INECompromissos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const NECompromissosForm: React.FC<NECompromissosFormProps> = ({
    necompromissosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoCompromisso, setNomeTipoCompromisso] = useState('');
            const tipocompromissoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipocompromisso") > 0) {
  tipocompromissoApi
    .getById(getParamFromUrl("tipocompromisso"))
    .then((response) => {
      setNomeTipoCompromisso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (necompromissosData.id === 0) {
    necompromissosData.tipocompromisso = getParamFromUrl("tipocompromisso");
  }
}
 const addValorTipoCompromisso = (e: any) => {
                        if (e?.id>0)
                        necompromissosData.tipocompromisso = e.id;
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
        console.error("Erro ao submeter formulário de NECompromissos:", error);
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
          target: document.getElementById(`NECompromissosForm-${necompromissosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar NECompromissos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-NECompromissos' : 'form-container5 form-container-NECompromissos'}>
       
            <form className='formInputCadInc' id={`NECompromissosForm-${necompromissosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={necompromissosData} isSubmitting={isSubmitting} onClose={onClose} formId={`NECompromissosForm-${necompromissosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="palavrachave"
label="PalavraChave"
className="inputIncNome"
name="palavrachave"
value={necompromissosData.palavrachave}
onChange={onChange}               
/>

<InputCheckbox label="Provisionar" name="provisionar" checked={necompromissosData.provisionar} onChange={onChange} />
 
            <TipoCompromissoComboBox
            name={'tipocompromisso'}
            value={necompromissosData.tipocompromisso}
            setValue={addValorTipoCompromisso}
            label={'Tipo Compromisso'}
            />

<InputInput
type="text"
id="textocompromisso"
label="TextoCompromisso"
className="inputIncNome"
name="textocompromisso"
value={necompromissosData.textocompromisso}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 