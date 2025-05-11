// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProDepositos } from '@/app/GerAdv_TS/ProDepositos/Interfaces/interface.ProDepositos';
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
import FaseComboBox from '@/app/GerAdv_TS/Fase/ComboBox/Fase';
import TipoProDespositoComboBox from '@/app/GerAdv_TS/TipoProDesposito/ComboBox/TipoProDesposito';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { FaseApi } from '@/app/GerAdv_TS/Fase/Apis/ApiFase';
import { TipoProDespositoApi } from '@/app/GerAdv_TS/TipoProDesposito/Apis/ApiTipoProDesposito';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface ProDepositosFormProps {
    prodepositosData: IProDepositos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProDepositosForm: React.FC<ProDepositosFormProps> = ({
    prodepositosData,
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
const [nomeFase, setNomeFase] = useState('');
            const faseApi = new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoProDesposito, setNomeTipoProDesposito] = useState('');
            const tipoprodespositoApi = new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodepositosData.id === 0) {
    prodepositosData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("fase") > 0) {
  faseApi
    .getById(getParamFromUrl("fase"))
    .then((response) => {
      setNomeFase(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodepositosData.id === 0) {
    prodepositosData.fase = getParamFromUrl("fase");
  }
}
 
if (getParamFromUrl("tipoprodesposito") > 0) {
  tipoprodespositoApi
    .getById(getParamFromUrl("tipoprodesposito"))
    .then((response) => {
      setNomeTipoProDesposito(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodepositosData.id === 0) {
    prodepositosData.tipoprodesposito = getParamFromUrl("tipoprodesposito");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        prodepositosData.processo = e.id;
                      };
 const addValorFase = (e: any) => {
                        if (e?.id>0)
                        prodepositosData.fase = e.id;
                      };
 const addValorTipoProDesposito = (e: any) => {
                        if (e?.id>0)
                        prodepositosData.tipoprodesposito = e.id;
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
        console.error("Erro ao submeter formulário de ProDepositos:", error);
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
          target: document.getElementById(`ProDepositosForm-${prodepositosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ProDepositos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ProDepositos' : 'form-container5 form-container-ProDepositos'}>
       
            <form className='formInputCadInc' id={`ProDepositosForm-${prodepositosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={prodepositosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProDepositosForm-${prodepositosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={prodepositosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <FaseComboBox
            name={'fase'}
            value={prodepositosData.fase}
            setValue={addValorFase}
            label={'Fase'}
            />

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={prodepositosData.data}
onChange={onChange}               
/>

<InputInput
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={prodepositosData.valor}
onChange={onChange}               
/>

            <TipoProDespositoComboBox
            name={'tipoprodesposito'}
            value={prodepositosData.tipoprodesposito}
            setValue={addValorTipoProDesposito}
            label={'Tipo Pro Desposito'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 