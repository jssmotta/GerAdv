"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IApenso } from '../../Interfaces/interface.Apenso';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

interface ApensoFormProps {
    apensoData: IApenso;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ApensoForm: React.FC<ApensoFormProps> = ({
    apensoData,
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
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (apensoData.id === 0) {
    apensoData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        apensoData.processo = e.id;
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

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={apensoData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="apensox"
label="Apenso"
className="inputIncNome"
name="apensox"
value={apensoData.apensox}
onChange={onChange}               
/>

<Input
type="text"
id="acao"
label="Acao"
className="inputIncNome"
name="acao"
value={apensoData.acao}
onChange={onChange}               
/>

<Input
type="text"
id="dtdist"
label="DtDist"
className="inputIncNome"
name="dtdist"
value={apensoData.dtdist}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={apensoData.obs}
onChange={onChange}               
/>

<Input
type="text"
id="valorcausa"
label="ValorCausa"
className="inputIncNome"
name="valorcausa"
value={apensoData.valorcausa}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/historico${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?apenso=${apensoData.id}`)}>Historico</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/nenotas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?apenso=${apensoData.id}`)}>N E Notas</div>

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
 