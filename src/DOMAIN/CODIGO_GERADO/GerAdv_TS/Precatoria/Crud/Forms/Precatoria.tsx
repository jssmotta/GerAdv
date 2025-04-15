"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IPrecatoria } from '../../Interfaces/interface.Precatoria';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

interface PrecatoriaFormProps {
    precatoriaData: IPrecatoria;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PrecatoriaForm: React.FC<PrecatoriaFormProps> = ({
    precatoriaData,
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

  if (precatoriaData.id === 0) {
    precatoriaData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        precatoriaData.processo = e.id;
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

<Input
type="text"
id="dtdist"
label="DtDist"
className="inputIncNome"
name="dtdist"
value={precatoriaData.dtdist}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={precatoriaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="precatoriax"
label="Precatoria"
className="inputIncNome"
name="precatoriax"
value={precatoriaData.precatoriax}
onChange={onChange}               
/>

<Input
type="text"
id="deprecante"
label="Deprecante"
className="inputIncNome"
name="deprecante"
value={precatoriaData.deprecante}
onChange={onChange}               
/>

<Input
type="text"
id="deprecado"
label="Deprecado"
className="inputIncNome"
name="deprecado"
value={precatoriaData.deprecado}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={precatoriaData.obs}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/historico${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?precatoria=${precatoriaData.id}`)}>Historico</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/nenotas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?precatoria=${precatoriaData.id}`)}>N E Notas</div>

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
 