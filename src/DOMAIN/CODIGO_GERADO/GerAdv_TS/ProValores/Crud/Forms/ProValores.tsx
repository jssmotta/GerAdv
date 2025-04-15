"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IProValores } from '../../Interfaces/interface.ProValores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import TipoValorProcessoComboBox from '@/app/GerAdv_TS/TipoValorProcesso/ComboBox/TipoValorProcesso';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { TipoValorProcessoApi } from '@/app/GerAdv_TS/TipoValorProcesso/Apis/ApiTipoValorProcesso';

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

  return (
  <>
  {nomeProcessos && (<h2>{nomeProcessos}</h2>)}
{nomeTipoValorProcesso && (<h2>{nomeTipoValorProcesso}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
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

<Checkbox label="Ignorar" name="ignorar" checked={provaloresData.ignorar} onChange={onChange} />
        
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
 