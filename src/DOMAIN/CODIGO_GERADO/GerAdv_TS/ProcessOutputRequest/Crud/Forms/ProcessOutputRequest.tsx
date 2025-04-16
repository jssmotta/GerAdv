"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IProcessOutputRequest } from '../../Interfaces/interface.ProcessOutputRequest';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessOutputEngineComboBox from '@/app/GerAdv_TS/ProcessOutputEngine/ComboBox/ProcessOutputEngine';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessOutputEngineApi } from '@/app/GerAdv_TS/ProcessOutputEngine/Apis/ApiProcessOutputEngine';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

interface ProcessOutputRequestFormProps {
    processoutputrequestData: IProcessOutputRequest;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProcessOutputRequestForm: React.FC<ProcessOutputRequestFormProps> = ({
    processoutputrequestData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessOutputEngine, setNomeProcessOutputEngine] = useState('');
            const processoutputengineApi = new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processoutputengine") > 0) {
  processoutputengineApi
    .getById(getParamFromUrl("processoutputengine"))
    .then((response) => {
      setNomeProcessOutputEngine(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processoutputrequestData.id === 0) {
    processoutputrequestData.processoutputengine = getParamFromUrl("processoutputengine");
  }
}
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processoutputrequestData.id === 0) {
    processoutputrequestData.operador = getParamFromUrl("operador");
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

  if (processoutputrequestData.id === 0) {
    processoutputrequestData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcessOutputEngine = (e: any) => {
                        if (e?.id>0)
                        processoutputrequestData.processoutputengine = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        processoutputrequestData.operador = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        processoutputrequestData.processo = e.id;
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
  {nomeProcessOutputEngine && (<h2>{nomeProcessOutputEngine}</h2>)}
{nomeOperador && (<h2>{nomeOperador}</h2>)}
{nomeProcessos && (<h2>{nomeProcessos}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ProcessOutputEngineComboBox
            name={'processoutputengine'}
            value={processoutputrequestData.processoutputengine}
            setValue={addValorProcessOutputEngine}
            label={'Process Output Engine'}
            />

            <OperadorComboBox
            name={'operador'}
            value={processoutputrequestData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={processoutputrequestData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="ultimoidtabelaexo"
label="UltimoIdTabelaExo"
className="inputIncNome"
name="ultimoidtabelaexo"
value={processoutputrequestData.ultimoidtabelaexo}
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
 