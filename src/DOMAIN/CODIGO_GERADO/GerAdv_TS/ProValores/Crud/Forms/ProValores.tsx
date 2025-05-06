// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProValores } from '@/app/GerAdv_TS/ProValores/Interfaces/interface.ProValores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import TipoValorProcessoComboBox from '@/app/GerAdv_TS/TipoValorProcesso/ComboBox/TipoValorProcesso';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { TipoValorProcessoApi } from '@/app/GerAdv_TS/TipoValorProcesso/Apis/ApiTipoValorProcesso';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ProValoresFormProps {
    provaloresData: IProValores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProValoresForm: React.FC<ProValoresFormProps> = ({
    provaloresData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoValorProcesso, setNomeTipoValorProcesso] = useState('');
            const tipovalorprocessoApi = new TipoValorProcessoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (provaloresData.id === 0) {
    provaloresData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("tipovalorprocesso") > 0) {
  tipovalorprocessoApi
    .getById(getParamFromUrl("tipovalorprocesso"))
    .then((response) => {
      setNomeTipoValorProcesso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (provaloresData.id === 0) {
    provaloresData.tipovalorprocesso = getParamFromUrl("tipovalorprocesso");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        provaloresData.processo = e.id;
                      };
 const addValorTipoValorProcesso = (e: any) => {
                        if (e?.id>0)
                        provaloresData.tipovalorprocesso = e.id;
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
      const formElement = document.getElementById('ProValoresForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`ProValoresForm-${provaloresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={provaloresData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProValoresForm-${provaloresData.id}`} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={provaloresData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <TipoValorProcessoComboBox
            name={'tipovalorprocesso'}
            value={provaloresData.tipovalorprocesso}
            setValue={addValorTipoValorProcesso}
            label={'Tipo Valor Processo'}
            />

<Input
type="text"
id="indice"
label="Indice"
className="inputIncNome"
name="indice"
value={provaloresData.indice}
onChange={onChange}               
/>

<InputCheckbox label="Ignorar" name="ignorar" checked={provaloresData.ignorar} onChange={onChange} />
        
<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={provaloresData.data}
onChange={onChange}               
/>

<Input
type="text"
id="valororiginal"
label="ValorOriginal"
className="inputIncNome"
name="valororiginal"
value={provaloresData.valororiginal}
onChange={onChange}               
/>

<Input
type="text"
id="percmulta"
label="PercMulta"
className="inputIncNome"
name="percmulta"
value={provaloresData.percmulta}
onChange={onChange}               
/>

<Input
type="text"
id="valormulta"
label="ValorMulta"
className="inputIncNome"
name="valormulta"
value={provaloresData.valormulta}
onChange={onChange}               
/>

<Input
type="text"
id="percjuros"
label="PercJuros"
className="inputIncNome"
name="percjuros"
value={provaloresData.percjuros}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="valororiginalcorrigidoindice"
label="ValorOriginalCorrigidoIndice"
className="inputIncNome"
name="valororiginalcorrigidoindice"
value={provaloresData.valororiginalcorrigidoindice}
onChange={onChange}               
/>

<Input
type="text"
id="valormultacorrigido"
label="ValorMultaCorrigido"
className="inputIncNome"
name="valormultacorrigido"
value={provaloresData.valormultacorrigido}
onChange={onChange}               
/>

<Input
type="text"
id="valorjuroscorrigido"
label="ValorJurosCorrigido"
className="inputIncNome"
name="valorjuroscorrigido"
value={provaloresData.valorjuroscorrigido}
onChange={onChange}               
/>

<Input
type="text"
id="valorfinal"
label="ValorFinal"
className="inputIncNome"
name="valorfinal"
value={provaloresData.valorfinal}
onChange={onChange}               
/>

<Input
type="text"
id="dataultimacorrecao"
label="DataUltimaCorrecao"
className="inputIncNome"
name="dataultimacorrecao"
value={provaloresData.dataultimacorrecao}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 