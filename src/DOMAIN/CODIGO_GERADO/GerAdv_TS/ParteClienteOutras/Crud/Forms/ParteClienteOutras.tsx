"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IParteClienteOutras } from '../../Interfaces/interface.ParteClienteOutras';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OutrasPartesClienteComboBox from '@/app/GerAdv_TS/OutrasPartesCliente/ComboBox/OutrasPartesCliente';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { OutrasPartesClienteApi } from '@/app/GerAdv_TS/OutrasPartesCliente/Apis/ApiOutrasPartesCliente';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeOutrasPartesCliente && (<h2>{nomeOutrasPartesCliente}</h2>)}
{nomeProcessos && (<h2>{nomeProcessos}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
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

<Checkbox label="PrimeiraReclamada" name="primeirareclamada" checked={parteclienteoutrasData.primeirareclamada} onChange={onChange} />

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
 