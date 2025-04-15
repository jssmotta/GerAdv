"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IPoderJudiciarioAssociado } from '../../Interfaces/interface.PoderJudiciarioAssociado';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import TribunalComboBox from '@/app/GerAdv_TS/Tribunal/ComboBox/Tribunal';
import ForoComboBox from '@/app/GerAdv_TS/Foro/ComboBox/Foro';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { TribunalApi } from '@/app/GerAdv_TS/Tribunal/Apis/ApiTribunal';
import { ForoApi } from '@/app/GerAdv_TS/Foro/Apis/ApiForo';

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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeJustica && (<h2>{nomeJustica}</h2>)}
{nomeArea && (<h2>{nomeArea}</h2>)}
{nomeTribunal && (<h2>{nomeTribunal}</h2>)}
{nomeForo && (<h2>{nomeForo}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <JusticaComboBox
            name={'justica'}
            value={poderjudiciarioassociadoData.justica}
            setValue={addValorJustica}
            label={'Justica'}
            />

<Input
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

<Input
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

<Input
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

<Input
type="text"
id="foronome"
label="ForoNome"
className="inputIncNome"
name="foronome"
value={poderjudiciarioassociadoData.foronome}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={poderjudiciarioassociadoData.cidade}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="subdivisaonome"
label="SubDivisaoNome"
className="inputIncNome"
name="subdivisaonome"
value={poderjudiciarioassociadoData.subdivisaonome}
onChange={onChange}               
/>

<Input
type="text"
id="cidadenome"
label="CidadeNome"
className="inputIncNome"
name="cidadenome"
value={poderjudiciarioassociadoData.cidadenome}
onChange={onChange}               
/>

<Input
type="text"
id="subdivisao"
label="SubDivisao"
className="inputIncNome"
name="subdivisao"
value={poderjudiciarioassociadoData.subdivisao}
onChange={onChange}               
/>

<Input
type="text"
id="tipo"
label="Tipo"
className="inputIncNome"
name="tipo"
value={poderjudiciarioassociadoData.tipo}
onChange={onChange}               
/>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 