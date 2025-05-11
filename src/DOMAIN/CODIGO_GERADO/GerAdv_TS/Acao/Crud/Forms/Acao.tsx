// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAcao } from '@/app/GerAdv_TS/Acao/Interfaces/interface.Acao';
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
import InputDescription from '@/app/components/Inputs/InputDescription';

interface AcaoFormProps {
    acaoData: IAcao;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AcaoForm: React.FC<AcaoFormProps> = ({
    acaoData,
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

  if (acaoData.id === 0) {
    acaoData.justica = getParamFromUrl("justica");
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

  if (acaoData.id === 0) {
    acaoData.area = getParamFromUrl("area");
  }
}
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        acaoData.justica = e.id;
                      };
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        acaoData.area = e.id;
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
        console.error("Erro ao submeter formulário de Acao:", error);
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
          target: document.getElementById(`AcaoForm-${acaoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Acao diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Acao' : 'form-container5 form-container-Acao'}>
       
            <form className='formInputCadInc' id={`AcaoForm-${acaoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={acaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`AcaoForm-${acaoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="acao"
            className="inputIncNome"
            name="descricao"
            value={acaoData.descricao}
            placeholder={`Digite nome acao`}
            onChange={onChange}
            required
            disabled={acaoData.id > 0}
          />

            <JusticaComboBox
            name={'justica'}
            value={acaoData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

            <AreaComboBox
            name={'area'}
            value={acaoData.area}
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
 