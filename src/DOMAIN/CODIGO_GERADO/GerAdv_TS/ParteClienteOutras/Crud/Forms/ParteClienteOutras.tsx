// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IParteClienteOutras } from '@/app/GerAdv_TS/ParteClienteOutras/Interfaces/interface.ParteClienteOutras';
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

import OutrasPartesClienteComboBox from '@/app/GerAdv_TS/OutrasPartesCliente/ComboBox/OutrasPartesCliente';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { OutrasPartesClienteApi } from '@/app/GerAdv_TS/OutrasPartesCliente/Apis/ApiOutrasPartesCliente';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ParteClienteOutrasFormProps {
    parteclienteoutrasData: IParteClienteOutras;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ParteClienteOutrasForm: React.FC<ParteClienteOutrasFormProps> = ({
    parteclienteoutrasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOutrasPartesCliente, setNomeOutrasPartesCliente] = useState('');
            const outraspartesclienteApi = new OutrasPartesClienteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("outraspartescliente") > 0) {
  outraspartesclienteApi
    .getById(getParamFromUrl("outraspartescliente"))
    .then((response) => {
      setNomeOutrasPartesCliente(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (parteclienteoutrasData.id === 0) {
    parteclienteoutrasData.cliente = getParamFromUrl("outraspartescliente");
  }
}
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (parteclienteoutrasData.id === 0) {
    parteclienteoutrasData.processo = getParamFromUrl("processos");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        parteclienteoutrasData.cliente = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        parteclienteoutrasData.processo = e.id;
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
        console.error("Erro ao submeter formulário de ParteClienteOutras:", error);
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
          target: document.getElementById(`ParteClienteOutrasForm-${parteclienteoutrasData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ParteClienteOutras diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ParteClienteOutras' : 'form-container5 form-container-ParteClienteOutras'}>
       
            <form className='formInputCadInc' id={`ParteClienteOutrasForm-${parteclienteoutrasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={parteclienteoutrasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ParteClienteOutrasForm-${parteclienteoutrasData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <OutrasPartesClienteComboBox
            name={'cliente'}
            value={parteclienteoutrasData.cliente}
            setValue={addValorCliente}
            label={'Outras Partes Cliente'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={parteclienteoutrasData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputCheckbox label="PrimeiraReclamada" name="primeirareclamada" checked={parteclienteoutrasData.primeirareclamada} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 