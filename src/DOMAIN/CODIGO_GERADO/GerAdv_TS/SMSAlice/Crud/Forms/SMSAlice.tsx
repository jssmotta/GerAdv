"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ISMSAlice } from '../../Interfaces/interface.SMSAlice';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import TipoEMailComboBox from '@/app/GerAdv_TS/TipoEMail/ComboBox/TipoEMail';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { TipoEMailApi } from '@/app/GerAdv_TS/TipoEMail/Apis/ApiTipoEMail';

interface SMSAliceFormProps {
    smsaliceData: ISMSAlice;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const SMSAliceForm: React.FC<SMSAliceFormProps> = ({
    smsaliceData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoEMail, setNomeTipoEMail] = useState('');
            const tipoemailApi = new TipoEMailApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (smsaliceData.id === 0) {
    smsaliceData.operador = getParamFromUrl("operador");
  }
}
 
if (getParamFromUrl("tipoemail") > 0) {
  tipoemailApi
    .getById(getParamFromUrl("tipoemail"))
    .then((response) => {
      setNomeTipoEMail(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (smsaliceData.id === 0) {
    smsaliceData.tipoemail = getParamFromUrl("tipoemail");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        smsaliceData.operador = e.id;
                      };
 const addValorTipoEMail = (e: any) => {
                        if (e?.id>0)
                        smsaliceData.tipoemail = e.id;
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
  {nomeOperador && (<h2>{nomeOperador}</h2>)}
{nomeTipoEMail && (<h2>{nomeTipoEMail}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={smsaliceData.nome}
            onChange={onChange}
            required
          />

            <OperadorComboBox
            name={'operador'}
            value={smsaliceData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <TipoEMailComboBox
            name={'tipoemail'}
            value={smsaliceData.tipoemail}
            setValue={addValorTipoEMail}
            label={'Tipo E Mail'}
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
 