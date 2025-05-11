// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGUTAtividadesMatriz } from '@/app/GerAdv_TS/GUTAtividadesMatriz/Interfaces/interface.GUTAtividadesMatriz';
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

import GUTMatrizComboBox from '@/app/GerAdv_TS/GUTMatriz/ComboBox/GUTMatriz';
import GUTAtividadesComboBox from '@/app/GerAdv_TS/GUTAtividades/ComboBox/GUTAtividades';
import { GUTMatrizApi } from '@/app/GerAdv_TS/GUTMatriz/Apis/ApiGUTMatriz';
import { GUTAtividadesApi } from '@/app/GerAdv_TS/GUTAtividades/Apis/ApiGUTAtividades';
import InputName from '@/app/components/Inputs/InputName';

interface GUTAtividadesMatrizFormProps {
    gutatividadesmatrizData: IGUTAtividadesMatriz;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTAtividadesMatrizForm: React.FC<GUTAtividadesMatrizFormProps> = ({
    gutatividadesmatrizData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGUTMatriz, setNomeGUTMatriz] = useState('');
            const gutmatrizApi = new GUTMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeGUTAtividades, setNomeGUTAtividades] = useState('');
            const gutatividadesApi = new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("gutmatriz") > 0) {
  gutmatrizApi
    .getById(getParamFromUrl("gutmatriz"))
    .then((response) => {
      setNomeGUTMatriz(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutatividadesmatrizData.id === 0) {
    gutatividadesmatrizData.gutmatriz = getParamFromUrl("gutmatriz");
  }
}
 
if (getParamFromUrl("gutatividades") > 0) {
  gutatividadesApi
    .getById(getParamFromUrl("gutatividades"))
    .then((response) => {
      setNomeGUTAtividades(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutatividadesmatrizData.id === 0) {
    gutatividadesmatrizData.gutatividade = getParamFromUrl("gutatividades");
  }
}
 const addValorGUTMatriz = (e: any) => {
                        if (e?.id>0)
                        gutatividadesmatrizData.gutmatriz = e.id;
                      };
 const addValorGUTAtividade = (e: any) => {
                        if (e?.id>0)
                        gutatividadesmatrizData.gutatividade = e.id;
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
        console.error("Erro ao submeter formulário de GUTAtividadesMatriz:", error);
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
          target: document.getElementById(`GUTAtividadesMatrizForm-${gutatividadesmatrizData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar GUTAtividadesMatriz diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-GUTAtividadesMatriz' : 'form-container5 form-container-GUTAtividadesMatriz'}>
       
            <form className='formInputCadInc' id={`GUTAtividadesMatrizForm-${gutatividadesmatrizData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gutatividadesmatrizData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTAtividadesMatrizForm-${gutatividadesmatrizData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <GUTMatrizComboBox
            name={'gutmatriz'}
            value={gutatividadesmatrizData.gutmatriz}
            setValue={addValorGUTMatriz}
            label={'G U T Matriz'}
            />

            <GUTAtividadesComboBox
            name={'gutatividade'}
            value={gutatividadesmatrizData.gutatividade}
            setValue={addValorGUTAtividade}
            label={'G U T Atividades'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 