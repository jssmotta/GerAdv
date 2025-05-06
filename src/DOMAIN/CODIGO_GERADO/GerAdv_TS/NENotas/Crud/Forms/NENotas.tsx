// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { INENotas } from '@/app/GerAdv_TS/NENotas/Interfaces/interface.NENotas';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ApensoComboBox from '@/app/GerAdv_TS/Apenso/ComboBox/Apenso';
import PrecatoriaComboBox from '@/app/GerAdv_TS/Precatoria/ComboBox/Precatoria';
import InstanciaComboBox from '@/app/GerAdv_TS/Instancia/ComboBox/Instancia';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ApensoApi } from '@/app/GerAdv_TS/Apenso/Apis/ApiApenso';
import { PrecatoriaApi } from '@/app/GerAdv_TS/Precatoria/Apis/ApiPrecatoria';
import { InstanciaApi } from '@/app/GerAdv_TS/Instancia/Apis/ApiInstancia';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface NENotasFormProps {
    nenotasData: INENotas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const NENotasForm: React.FC<NENotasFormProps> = ({
    nenotasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeApenso, setNomeApenso] = useState('');
            const apensoApi = new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrecatoria, setNomePrecatoria] = useState('');
            const precatoriaApi = new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeInstancia, setNomeInstancia] = useState('');
            const instanciaApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("apenso") > 0) {
  apensoApi
    .getById(getParamFromUrl("apenso"))
    .then((response) => {
      setNomeApenso(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (nenotasData.id === 0) {
    nenotasData.apenso = getParamFromUrl("apenso");
  }
}
 
if (getParamFromUrl("precatoria") > 0) {
  precatoriaApi
    .getById(getParamFromUrl("precatoria"))
    .then((response) => {
      setNomePrecatoria(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (nenotasData.id === 0) {
    nenotasData.precatoria = getParamFromUrl("precatoria");
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

  if (nenotasData.id === 0) {
    nenotasData.instancia = getParamFromUrl("instancia");
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

  if (nenotasData.id === 0) {
    nenotasData.processo = getParamFromUrl("processos");
  }
}
 const addValorApenso = (e: any) => {
                        if (e?.id>0)
                        nenotasData.apenso = e.id;
                      };
 const addValorPrecatoria = (e: any) => {
                        if (e?.id>0)
                        nenotasData.precatoria = e.id;
                      };
 const addValorInstancia = (e: any) => {
                        if (e?.id>0)
                        nenotasData.instancia = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        nenotasData.processo = e.id;
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
      const formElement = document.getElementById('NENotasForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`NENotasForm-${nenotasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={nenotasData} isSubmitting={isSubmitting} onClose={onClose} formId={`NENotasForm-${nenotasData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={nenotasData.nome}
            placeholder={`Digite nome n e notas`}
            onChange={onChange}
            required
          />

            <ApensoComboBox
            name={'apenso'}
            value={nenotasData.apenso}
            setValue={addValorApenso}
            label={'Apenso'}
            />

            <PrecatoriaComboBox
            name={'precatoria'}
            value={nenotasData.precatoria}
            setValue={addValorPrecatoria}
            label={'Precatoria'}
            />

            <InstanciaComboBox
            name={'instancia'}
            value={nenotasData.instancia}
            setValue={addValorInstancia}
            label={'Instancia'}
            />

<InputCheckbox label="MovPro" name="movpro" checked={nenotasData.movpro} onChange={onChange} />
<InputCheckbox label="NotaExpedida" name="notaexpedida" checked={nenotasData.notaexpedida} onChange={onChange} />
<InputCheckbox label="Revisada" name="revisada" checked={nenotasData.revisada} onChange={onChange} />
 
            <ProcessosComboBox
            name={'processo'}
            value={nenotasData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="palavrachave"
label="PalavraChave"
className="inputIncNome"
name="palavrachave"
value={nenotasData.palavrachave}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={nenotasData.data}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="notapublicada"
label="NotaPublicada"
className="inputIncNome"
name="notapublicada"
value={nenotasData.notapublicada}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 