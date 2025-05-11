// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAreasJustica } from '@/app/GerAdv_TS/AreasJustica/Interfaces/interface.AreasJustica';
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

import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import InputName from '@/app/components/Inputs/InputName';

interface AreasJusticaFormProps {
    areasjusticaData: IAreasJustica;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AreasJusticaForm: React.FC<AreasJusticaFormProps> = ({
    areasjusticaData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeArea, setNomeArea] = useState('');
            const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
            const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (areasjusticaData.id === 0) {
    areasjusticaData.area = getParamFromUrl("area");
  }
}
 
if (getParamFromUrl("justica") > 0) {
  justicaApi
    .getById(getParamFromUrl("justica"))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (areasjusticaData.id === 0) {
    areasjusticaData.justica = getParamFromUrl("justica");
  }
}
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        areasjusticaData.area = e.id;
                      };
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        areasjusticaData.justica = e.id;
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
        console.error("Erro ao submeter formulário de AreasJustica:", error);
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
          target: document.getElementById(`AreasJusticaForm-${areasjusticaData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AreasJustica diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AreasJustica' : 'form-container5 form-container-AreasJustica'}>
       
            <form className='formInputCadInc' id={`AreasJusticaForm-${areasjusticaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={areasjusticaData} isSubmitting={isSubmitting} onClose={onClose} formId={`AreasJusticaForm-${areasjusticaData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <AreaComboBox
            name={'area'}
            value={areasjusticaData.area}
            setValue={addValorArea}
            label={'Area'}
            />

            <JusticaComboBox
            name={'justica'}
            value={areasjusticaData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 