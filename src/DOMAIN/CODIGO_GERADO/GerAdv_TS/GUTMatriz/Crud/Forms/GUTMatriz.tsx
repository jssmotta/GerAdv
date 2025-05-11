// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGUTMatriz } from '@/app/GerAdv_TS/GUTMatriz/Interfaces/interface.GUTMatriz';
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

import GUTTipoComboBox from '@/app/GerAdv_TS/GUTTipo/ComboBox/GUTTipo';
import { GUTTipoApi } from '@/app/GerAdv_TS/GUTTipo/Apis/ApiGUTTipo';
import InputDescription from '@/app/components/Inputs/InputDescription';
import InputInput from '@/app/components/Inputs/InputInput'

interface GUTMatrizFormProps {
    gutmatrizData: IGUTMatriz;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTMatrizForm: React.FC<GUTMatrizFormProps> = ({
    gutmatrizData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGUTTipo, setNomeGUTTipo] = useState('');
            const guttipoApi = new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("guttipo") > 0) {
  guttipoApi
    .getById(getParamFromUrl("guttipo"))
    .then((response) => {
      setNomeGUTTipo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutmatrizData.id === 0) {
    gutmatrizData.guttipo = getParamFromUrl("guttipo");
  }
}
 const addValorGUTTipo = (e: any) => {
                        if (e?.id>0)
                        gutmatrizData.guttipo = e.id;
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
        console.error("Erro ao submeter formulário de GUTMatriz:", error);
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
          target: document.getElementById(`GUTMatrizForm-${gutmatrizData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar GUTMatriz diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-GUTMatriz' : 'form-container5 form-container-GUTMatriz'}>
       
            <form className='formInputCadInc' id={`GUTMatrizForm-${gutmatrizData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gutmatrizData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTMatrizForm-${gutmatrizData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="g u t matriz"
            className="inputIncNome"
            name="descricao"
            value={gutmatrizData.descricao}
            placeholder={`Digite nome g u t matriz`}
            onChange={onChange}
            required
            disabled={gutmatrizData.id > 0}
          />

            <GUTTipoComboBox
            name={'guttipo'}
            value={gutmatrizData.guttipo}
            setValue={addValorGUTTipo}
            label={'G U T Tipo'}
            />

<InputInput
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={gutmatrizData.valor}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 