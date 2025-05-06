// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProProcuradores } from '@/app/GerAdv_TS/ProProcuradores/Interfaces/interface.ProProcuradores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ProProcuradoresFormProps {
    proprocuradoresData: IProProcuradores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProProcuradoresForm: React.FC<ProProcuradoresFormProps> = ({
    proprocuradoresData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAdvogados, setNomeAdvogados] = useState('');
            const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (proprocuradoresData.id === 0) {
    proprocuradoresData.advogado = getParamFromUrl("advogados");
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

  if (proprocuradoresData.id === 0) {
    proprocuradoresData.processo = getParamFromUrl("processos");
  }
}
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        proprocuradoresData.advogado = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        proprocuradoresData.processo = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('ProProcuradoresForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`ProProcuradoresForm-${proprocuradoresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={proprocuradoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProProcuradoresForm-${proprocuradoresData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={proprocuradoresData.nome}
            placeholder={`Digite nome pro procuradores`}
            onChange={onChange}
            required
          />

            <AdvogadosComboBox
            name={'advogado'}
            value={proprocuradoresData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={proprocuradoresData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={proprocuradoresData.data}
onChange={onChange}               
/>

<InputCheckbox label="Substabelecimento" name="substabelecimento" checked={proprocuradoresData.substabelecimento} onChange={onChange} />
<InputCheckbox label="Procuracao" name="procuracao" checked={proprocuradoresData.procuracao} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 