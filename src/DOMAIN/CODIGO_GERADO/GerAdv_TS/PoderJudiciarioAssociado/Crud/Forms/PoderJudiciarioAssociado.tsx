// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPoderJudiciarioAssociado } from '@/app/GerAdv_TS/PoderJudiciarioAssociado/Interfaces/interface.PoderJudiciarioAssociado';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import TribunalComboBox from '@/app/GerAdv_TS/Tribunal/ComboBox/Tribunal';
import ForoComboBox from '@/app/GerAdv_TS/Foro/ComboBox/Foro';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { TribunalApi } from '@/app/GerAdv_TS/Tribunal/Apis/ApiTribunal';
import { ForoApi } from '@/app/GerAdv_TS/Foro/Apis/ApiForo';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface PoderJudiciarioAssociadoFormProps {
    poderjudiciarioassociadoData: IPoderJudiciarioAssociado;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PoderJudiciarioAssociadoForm: React.FC<PoderJudiciarioAssociadoFormProps> = ({
    poderjudiciarioassociadoData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeJustica, setNomeJustica] = useState('');
            const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
            const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTribunal, setNomeTribunal] = useState('');
            const tribunalApi = new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeForo, setNomeForo] = useState('');
            const foroApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("justica") > 0) {
  justicaApi
    .getById(getParamFromUrl("justica"))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (poderjudiciarioassociadoData.id === 0) {
    poderjudiciarioassociadoData.justica = getParamFromUrl("justica");
  }
}
 
if (getParamFromUrl("area") > 0) {
  areaApi
    .getById(getParamFromUrl("area"))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (poderjudiciarioassociadoData.id === 0) {
    poderjudiciarioassociadoData.area = getParamFromUrl("area");
  }
}
 
if (getParamFromUrl("tribunal") > 0) {
  tribunalApi
    .getById(getParamFromUrl("tribunal"))
    .then((response) => {
      setNomeTribunal(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (poderjudiciarioassociadoData.id === 0) {
    poderjudiciarioassociadoData.tribunal = getParamFromUrl("tribunal");
  }
}
 
if (getParamFromUrl("foro") > 0) {
  foroApi
    .getById(getParamFromUrl("foro"))
    .then((response) => {
      setNomeForo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (poderjudiciarioassociadoData.id === 0) {
    poderjudiciarioassociadoData.foro = getParamFromUrl("foro");
  }
}
 const addValorJustica = (e: any) => {
                        if (e?.id>0)
                        poderjudiciarioassociadoData.justica = e.id;
                      };
 const addValorArea = (e: any) => {
                        if (e?.id>0)
                        poderjudiciarioassociadoData.area = e.id;
                      };
 const addValorTribunal = (e: any) => {
                        if (e?.id>0)
                        poderjudiciarioassociadoData.tribunal = e.id;
                      };
 const addValorForo = (e: any) => {
                        if (e?.id>0)
                        poderjudiciarioassociadoData.foro = e.id;
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
        console.error("Erro ao submeter formulário de PoderJudiciarioAssociado:", error);
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
          target: document.getElementById(`PoderJudiciarioAssociadoForm-${poderjudiciarioassociadoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar PoderJudiciarioAssociado diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-PoderJudiciarioAssociado' : 'form-container form-container-PoderJudiciarioAssociado'}>
       
            <form className='formInputCadInc' id={`PoderJudiciarioAssociadoForm-${poderjudiciarioassociadoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={poderjudiciarioassociadoData} isSubmitting={isSubmitting} onClose={onClose} formId={`PoderJudiciarioAssociadoForm-${poderjudiciarioassociadoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <JusticaComboBox
            name={'justica'}
            value={poderjudiciarioassociadoData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

<InputInput
type="text"
id="justicanome"
label="JusticaNome"
className="inputIncNome"
name="justicanome"
value={poderjudiciarioassociadoData.justicanome}
onChange={onChange}               
/>

            <AreaComboBox
            name={'area'}
            value={poderjudiciarioassociadoData.area}
            setValue={addValorArea}
            label={'Area'}
            />

<InputInput
type="text"
id="areanome"
label="AreaNome"
className="inputIncNome"
name="areanome"
value={poderjudiciarioassociadoData.areanome}
onChange={onChange}               
/>

            <TribunalComboBox
            name={'tribunal'}
            value={poderjudiciarioassociadoData.tribunal}
            setValue={addValorTribunal}
            label={'Tribunal'}
            />

<InputInput
type="text"
id="tribunalnome"
label="TribunalNome"
className="inputIncNome"
name="tribunalnome"
value={poderjudiciarioassociadoData.tribunalnome}
onChange={onChange}               
/>

            <ForoComboBox
            name={'foro'}
            value={poderjudiciarioassociadoData.foro}
            setValue={addValorForo}
            label={'Foro'}
            />

<InputInput
type="text"
id="foronome"
label="ForoNome"
className="inputIncNome"
name="foronome"
value={poderjudiciarioassociadoData.foronome}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={poderjudiciarioassociadoData.cidade}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="subdivisaonome"
label="SubDivisaoNome"
className="inputIncNome"
name="subdivisaonome"
value={poderjudiciarioassociadoData.subdivisaonome}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidadenome"
label="CidadeNome"
className="inputIncNome"
name="cidadenome"
value={poderjudiciarioassociadoData.cidadenome}
onChange={onChange}               
/>

<InputInput
type="text"
id="subdivisao"
label="SubDivisao"
className="inputIncNome"
name="subdivisao"
value={poderjudiciarioassociadoData.subdivisao}
onChange={onChange}               
/>

<InputInput
type="text"
id="tipo"
label="Tipo"
className="inputIncNome"
name="tipo"
value={poderjudiciarioassociadoData.tipo}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 