// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ITribunal } from '@/app/GerAdv_TS/Tribunal/Interfaces/interface.Tribunal';
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
import InstanciaComboBox from '@/app/GerAdv_TS/Instancia/ComboBox/Instancia';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { InstanciaApi } from '@/app/GerAdv_TS/Instancia/Apis/ApiInstancia';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface TribunalFormProps {
    tribunalData: ITribunal;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TribunalForm: React.FC<TribunalFormProps> = ({
    tribunalData,
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
const [nomeInstancia, setNomeInstancia] = useState('');
            const instanciaApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (tribunalData.id === 0) {
    tribunalData.area = getParamFromUrl("area");
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

  if (tribunalData.id === 0) {
    tribunalData.justica = getParamFromUrl("justica");
  }
}
 
if (getParamFromUrl("instancia") > 0) {
  instanciaApi
    .getById(getParamFromUrl("instancia"))
    .then((response) => {
      setNomeInstancia(response.data.nroprocesso);
    })
    .catch((error) => {
      console.error(error);
    });

  if (tribunalData.id === 0) {
    tribunalData.instancia = getParamFromUrl("instancia");
  }
}
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        tribunalData.area = e.id;
                      };
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        tribunalData.justica = e.id;
                      };
 const addValorInstancia = (e: any) => {
                        if (e?.id>0)
                        tribunalData.instancia = e.id;
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
        console.error("Erro ao submeter formulário de Tribunal:", error);
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
          target: document.getElementById(`TribunalForm-${tribunalData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Tribunal diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Tribunal' : 'form-container5 form-container-Tribunal'}>
       
            <form className='formInputCadInc' id={`TribunalForm-${tribunalData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={tribunalData} isSubmitting={isSubmitting} onClose={onClose} formId={`TribunalForm-${tribunalData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={tribunalData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <AreaComboBox
            name={'area'}
            value={tribunalData.area}
            setValue={addValorArea}
            label={'Area'}
            />

            <JusticaComboBox
            name={'justica'}
            value={tribunalData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

<InputInput
type="text"
id="descricao"
label="Descricao"
className="inputIncNome"
name="descricao"
value={tribunalData.descricao}
onChange={onChange}               
/>

            <InstanciaComboBox
            name={'instancia'}
            value={tribunalData.instancia}
            setValue={addValorInstancia}
            label={'Instancia'}
            />

<InputInput
type="text"
id="sigla"
label="Sigla"
className="inputIncNome"
name="sigla"
value={tribunalData.sigla}
onChange={onChange}               
/>

<InputInput
type="text"
id="web"
label="Web"
className="inputIncNome"
name="web"
value={tribunalData.web}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 