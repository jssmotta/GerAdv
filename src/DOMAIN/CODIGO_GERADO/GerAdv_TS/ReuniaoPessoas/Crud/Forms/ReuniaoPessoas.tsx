"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IReuniaoPessoas } from '../../Interfaces/interface.ReuniaoPessoas';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ReuniaoComboBox from '@/app/GerAdv_TS/Reuniao/ComboBox/Reuniao';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { ReuniaoApi } from '@/app/GerAdv_TS/Reuniao/Apis/ApiReuniao';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';

interface ReuniaoPessoasFormProps {
    reuniaopessoasData: IReuniaoPessoas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ReuniaoPessoasForm: React.FC<ReuniaoPessoasFormProps> = ({
    reuniaopessoasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeReuniao, setNomeReuniao] = useState('');
            const reuniaoApi = new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("reuniao") > 0) {
  reuniaoApi
    .getById(getParamFromUrl("reuniao"))
    .then((response) => {
      setNomeReuniao(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (reuniaopessoasData.id === 0) {
    reuniaopessoasData.reuniao = getParamFromUrl("reuniao");
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

  if (reuniaopessoasData.id === 0) {
    reuniaopessoasData.operador = getParamFromUrl("operador");
  }
}
 const addValorReuniao = (e: any) => {
                        if (e?.id>0)
                        reuniaopessoasData.reuniao = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        reuniaopessoasData.operador = e.id;
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
  {nomeReuniao && (<h2>{nomeReuniao}</h2>)}
{nomeOperador && (<h2>{nomeOperador}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ReuniaoComboBox
            name={'reuniao'}
            value={reuniaopessoasData.reuniao}
            setValue={addValorReuniao}
            label={'Reuniao'}
            />

            <OperadorComboBox
            name={'operador'}
            value={reuniaopessoasData.operador}
            setValue={addValorOperador}
            label={'Operador'}
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
 