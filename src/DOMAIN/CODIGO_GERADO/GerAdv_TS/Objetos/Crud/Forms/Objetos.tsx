// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IObjetos } from '@/app/GerAdv_TS/Objetos/Interfaces/interface.Objetos';
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

import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import InputName from '@/app/components/Inputs/InputName';

interface ObjetosFormProps {
    objetosData: IObjetos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ObjetosForm: React.FC<ObjetosFormProps> = ({
    objetosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeJustica, setNomeJustica] = useState('');
            const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
            const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("justica") > 0) {
  justicaApi
    .getById(getParamFromUrl("justica"))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (objetosData.id === 0) {
    objetosData.justica = getParamFromUrl("justica");
  }
}
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (objetosData.id === 0) {
    objetosData.area = getParamFromUrl("area");
  }
}
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        objetosData.justica = e.id;
                      };
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        objetosData.area = e.id;
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
        console.error("Erro ao submeter formulário de Objetos:", error);
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
          target: document.getElementById(`ObjetosForm-${objetosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Objetos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Objetos' : 'form-container5 form-container-Objetos'}>
       
            <form className='formInputCadInc' id={`ObjetosForm-${objetosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={objetosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ObjetosForm-${objetosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={objetosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <JusticaComboBox
            name={'justica'}
            value={objetosData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

            <AreaComboBox
            name={'area'}
            value={objetosData.area}
            setValue={addValorArea}
            label={'Area'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 