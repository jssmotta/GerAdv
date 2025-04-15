"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IStatusBiu } from '../../Interfaces/interface.StatusBiu';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import TipoStatusBiuComboBox from '@/app/GerAdv_TS/TipoStatusBiu/ComboBox/TipoStatusBiu';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { TipoStatusBiuApi } from '@/app/GerAdv_TS/TipoStatusBiu/Apis/ApiTipoStatusBiu';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';

interface StatusBiuFormProps {
    statusbiuData: IStatusBiu;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const StatusBiuForm: React.FC<StatusBiuFormProps> = ({
    statusbiuData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoStatusBiu, setNomeTipoStatusBiu] = useState('');
            const tipostatusbiuApi = new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipostatusbiu") > 0) {
  tipostatusbiuApi
    .getById(getParamFromUrl("tipostatusbiu"))
    .then((response) => {
      setNomeTipoStatusBiu(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (statusbiuData.id === 0) {
    statusbiuData.tipostatusbiu = getParamFromUrl("tipostatusbiu");
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

  if (statusbiuData.id === 0) {
    statusbiuData.operador = getParamFromUrl("operador");
  }
}
 const addValorTipoStatusBiu = (e: any) => {
                        if (e?.id>0)
                        statusbiuData.tipostatusbiu = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        statusbiuData.operador = e.id;
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
  {nomeTipoStatusBiu && (<h2>{nomeTipoStatusBiu}</h2>)}
{nomeOperador && (<h2>{nomeOperador}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={statusbiuData.nome}
            onChange={onChange}
            required
          />

            <TipoStatusBiuComboBox
            name={'tipostatusbiu'}
            value={statusbiuData.tipostatusbiu}
            setValue={addValorTipoStatusBiu}
            label={'Staus  Usuários'}
            />

            <OperadorComboBox
            name={'operador'}
            value={statusbiuData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<Input
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={statusbiuData.icone}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/operador${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?statusbiu=${statusbiuData.id}`)}>Operador</div>

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
 