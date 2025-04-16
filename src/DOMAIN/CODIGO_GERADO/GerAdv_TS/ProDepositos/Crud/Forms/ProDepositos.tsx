"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IProDepositos } from '../../Interfaces/interface.ProDepositos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import FaseComboBox from '@/app/GerAdv_TS/Fase/ComboBox/Fase';
import TipoProDespositoComboBox from '@/app/GerAdv_TS/TipoProDesposito/ComboBox/TipoProDesposito';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { FaseApi } from '@/app/GerAdv_TS/Fase/Apis/ApiFase';
import { TipoProDespositoApi } from '@/app/GerAdv_TS/TipoProDesposito/Apis/ApiTipoProDesposito';

interface ProDepositosFormProps {
    prodepositosData: IProDepositos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProDepositosForm: React.FC<ProDepositosFormProps> = ({
    prodepositosData,
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
const [nomeFase, setNomeFase] = useState('');
            const faseApi = new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoProDesposito, setNomeTipoProDesposito] = useState('');
            const tipoprodespositoApi = new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodepositosData.id === 0) {
    prodepositosData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("fase") > 0) {
  faseApi
    .getById(getParamFromUrl("fase"))
    .then((response) => {
      setNomeFase(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodepositosData.id === 0) {
    prodepositosData.fase = getParamFromUrl("fase");
  }
}
 
if (getParamFromUrl("tipoprodesposito") > 0) {
  tipoprodespositoApi
    .getById(getParamFromUrl("tipoprodesposito"))
    .then((response) => {
      setNomeTipoProDesposito(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodepositosData.id === 0) {
    prodepositosData.tipoprodesposito = getParamFromUrl("tipoprodesposito");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        prodepositosData.processo = e.id;
                      };
 const addValorFase = (e: any) => {
                        if (e?.id>0)
                        prodepositosData.fase = e.id;
                      };
 const addValorTipoProDesposito = (e: any) => {
                        if (e?.id>0)
                        prodepositosData.tipoprodesposito = e.id;
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
{nomeFase && (<h2>{nomeFase}</h2>)}
{nomeTipoProDesposito && (<h2>{nomeTipoProDesposito}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={prodepositosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <FaseComboBox
            name={'fase'}
            value={prodepositosData.fase}
            setValue={addValorFase}
            label={'Fase'}
            />

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={prodepositosData.data}
onChange={onChange}               
/>

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={prodepositosData.valor}
onChange={onChange}               
/>

            <TipoProDespositoComboBox
            name={'tipoprodesposito'}
            value={prodepositosData.tipoprodesposito}
            setValue={addValorTipoProDesposito}
            label={'Tipo Pro Desposito'}
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
 