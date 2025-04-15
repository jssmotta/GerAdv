"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ILivroCaixaClientes } from '../../Interfaces/interface.LivroCaixaClientes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import LivroCaixaComboBox from '@/app/GerAdv_TS/LivroCaixa/ComboBox/LivroCaixa';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { LivroCaixaApi } from '@/app/GerAdv_TS/LivroCaixa/Apis/ApiLivroCaixa';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';

interface LivroCaixaClientesFormProps {
    livrocaixaclientesData: ILivroCaixaClientes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const LivroCaixaClientesForm: React.FC<LivroCaixaClientesFormProps> = ({
    livrocaixaclientesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeLivroCaixa, setNomeLivroCaixa] = useState('');
            const livrocaixaApi = new LivroCaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("livrocaixa") > 0) {
  livrocaixaApi
    .getById(getParamFromUrl("livrocaixa"))
    .then((response) => {
      setNomeLivroCaixa(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (livrocaixaclientesData.id === 0) {
    livrocaixaclientesData.livrocaixa = getParamFromUrl("livrocaixa");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (livrocaixaclientesData.id === 0) {
    livrocaixaclientesData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorLivroCaixa = (e: any) => {
                        if (e?.id>0)
                        livrocaixaclientesData.livrocaixa = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        livrocaixaclientesData.cliente = e.id;
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
  {nomeLivroCaixa && (<h2>{nomeLivroCaixa}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <LivroCaixaComboBox
            name={'livrocaixa'}
            value={livrocaixaclientesData.livrocaixa}
            setValue={addValorLivroCaixa}
            label={'Livro Caixa'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={livrocaixaclientesData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Checkbox label="Lancado" name="lancado" checked={livrocaixaclientesData.lancado} onChange={onChange} />

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
 