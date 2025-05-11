// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IStatusBiu } from '@/app/GerAdv_TS/StatusBiu/Interfaces/interface.StatusBiu';
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

import TipoStatusBiuComboBox from '@/app/GerAdv_TS/TipoStatusBiu/ComboBox/TipoStatusBiu';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { TipoStatusBiuApi } from '@/app/GerAdv_TS/TipoStatusBiu/Apis/ApiTipoStatusBiu';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface StatusBiuFormProps {
    statusbiuData: IStatusBiu;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const StatusBiuForm: React.FC<StatusBiuFormProps> = ({
    statusbiuData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoStatusBiu, setNomeTipoStatusBiu] = useState('');
            const tipostatusbiuApi = new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipostatusbiu") > 0) {
  tipostatusbiuApi
    .getById(getParamFromUrl("tipostatusbiu"))
    .then((response) => {
      setNomeTipoStatusBiu(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (statusbiuData.id === 0) {
    statusbiuData.tipostatusbiu = getParamFromUrl("tipostatusbiu");
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

  if (statusbiuData.id === 0) {
    statusbiuData.operador = getParamFromUrl("operador");
  }
}
 const addValorTipoStatusBiu = (e: any) => {
                        if (e?.id>0)
                        statusbiuData.tipostatusbiu = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        statusbiuData.operador = e.id;
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
        console.error("Erro ao submeter formulário de StatusBiu:", error);
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
          target: document.getElementById(`StatusBiuForm-${statusbiuData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar StatusBiu diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-StatusBiu' : 'form-container5 form-container-StatusBiu'}>
       
            <form className='formInputCadInc' id={`StatusBiuForm-${statusbiuData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={statusbiuData} isSubmitting={isSubmitting} onClose={onClose} formId={`StatusBiuForm-${statusbiuData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={statusbiuData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <TipoStatusBiuComboBox
            name={'tipostatusbiu'}
            value={statusbiuData.tipostatusbiu}
            setValue={addValorTipoStatusBiu}
            label={'Staus  Usuários'}
            />

            <OperadorComboBox
            name={'operador'}
            value={statusbiuData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputInput
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={statusbiuData.icone}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 