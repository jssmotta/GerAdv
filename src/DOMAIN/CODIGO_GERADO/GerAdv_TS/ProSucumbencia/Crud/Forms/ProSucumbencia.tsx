// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProSucumbencia } from '@/app/GerAdv_TS/ProSucumbencia/Interfaces/interface.ProSucumbencia';
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

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import InstanciaComboBox from '@/app/GerAdv_TS/Instancia/ComboBox/Instancia';
import TipoOrigemSucumbenciaComboBox from '@/app/GerAdv_TS/TipoOrigemSucumbencia/ComboBox/TipoOrigemSucumbencia';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { InstanciaApi } from '@/app/GerAdv_TS/Instancia/Apis/ApiInstancia';
import { TipoOrigemSucumbenciaApi } from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Apis/ApiTipoOrigemSucumbencia';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface ProSucumbenciaFormProps {
    prosucumbenciaData: IProSucumbencia;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProSucumbenciaForm: React.FC<ProSucumbenciaFormProps> = ({
    prosucumbenciaData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeInstancia, setNomeInstancia] = useState('');
            const instanciaApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoOrigemSucumbencia, setNomeTipoOrigemSucumbencia] = useState('');
            const tipoorigemsucumbenciaApi = new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prosucumbenciaData.id === 0) {
    prosucumbenciaData.processo = getParamFromUrl("processos");
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

  if (prosucumbenciaData.id === 0) {
    prosucumbenciaData.instancia = getParamFromUrl("instancia");
  }
}
 
if (getParamFromUrl("tipoorigemsucumbencia") > 0) {
  tipoorigemsucumbenciaApi
    .getById(getParamFromUrl("tipoorigemsucumbencia"))
    .then((response) => {
      setNomeTipoOrigemSucumbencia(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prosucumbenciaData.id === 0) {
    prosucumbenciaData.tipoorigemsucumbencia = getParamFromUrl("tipoorigemsucumbencia");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        prosucumbenciaData.processo = e.id;
                      };
 const addValorInstancia = (e: any) => {
                        if (e?.id>0)
                        prosucumbenciaData.instancia = e.id;
                      };
 const addValorTipoOrigemSucumbencia = (e: any) => {
                        if (e?.id>0)
                        prosucumbenciaData.tipoorigemsucumbencia = e.id;
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
        console.error("Erro ao submeter formulário de ProSucumbencia:", error);
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
          target: document.getElementById(`ProSucumbenciaForm-${prosucumbenciaData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ProSucumbencia diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ProSucumbencia' : 'form-container5 form-container-ProSucumbencia'}>
       
            <form className='formInputCadInc' id={`ProSucumbenciaForm-${prosucumbenciaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={prosucumbenciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProSucumbenciaForm-${prosucumbenciaData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={prosucumbenciaData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <ProcessosComboBox
            name={'processo'}
            value={prosucumbenciaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <InstanciaComboBox
            name={'instancia'}
            value={prosucumbenciaData.instancia}
            setValue={addValorInstancia}
            label={'Instancia'}
            />

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={prosucumbenciaData.data}
onChange={onChange}               
/>

            <TipoOrigemSucumbenciaComboBox
            name={'tipoorigemsucumbencia'}
            value={prosucumbenciaData.tipoorigemsucumbencia}
            setValue={addValorTipoOrigemSucumbencia}
            label={'Tipo Origem Sucumbencia'}
            />

<InputInput
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={prosucumbenciaData.valor}
onChange={onChange}               
/>

<InputInput
type="text"
id="percentual"
label="Percentual"
className="inputIncNome"
name="percentual"
value={prosucumbenciaData.percentual}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 