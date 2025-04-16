"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IParceriaProc } from '../../Interfaces/interface.ParceriaProc';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

interface ParceriaProcFormProps {
    parceriaprocData: IParceriaProc;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ParceriaProcForm: React.FC<ParceriaProcFormProps> = ({
    parceriaprocData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAdvogados, setNomeAdvogados] = useState('');
            const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (parceriaprocData.id === 0) {
    parceriaprocData.advogado = getParamFromUrl("advogados");
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

  if (parceriaprocData.id === 0) {
    parceriaprocData.processo = getParamFromUrl("processos");
  }
}
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        parceriaprocData.advogado = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        parceriaprocData.processo = e.id;
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
  {nomeAdvogados && (<h2>{nomeAdvogados}</h2>)}
{nomeProcessos && (<h2>{nomeProcessos}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <AdvogadosComboBox
            name={'advogado'}
            value={parceriaprocData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={parceriaprocData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
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
 