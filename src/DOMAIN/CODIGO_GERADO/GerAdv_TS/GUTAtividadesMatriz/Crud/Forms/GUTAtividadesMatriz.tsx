"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IGUTAtividadesMatriz } from '../../Interfaces/interface.GUTAtividadesMatriz';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import GUTMatrizComboBox from '@/app/GerAdv_TS/GUTMatriz/ComboBox/GUTMatriz';
import GUTAtividadesComboBox from '@/app/GerAdv_TS/GUTAtividades/ComboBox/GUTAtividades';
import { GUTMatrizApi } from '@/app/GerAdv_TS/GUTMatriz/Apis/ApiGUTMatriz';
import { GUTAtividadesApi } from '@/app/GerAdv_TS/GUTAtividades/Apis/ApiGUTAtividades';

interface GUTAtividadesMatrizFormProps {
    gutatividadesmatrizData: IGUTAtividadesMatriz;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTAtividadesMatrizForm: React.FC<GUTAtividadesMatrizFormProps> = ({
    gutatividadesmatrizData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGUTMatriz, setNomeGUTMatriz] = useState('');
            const gutmatrizApi = new GUTMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeGUTAtividades, setNomeGUTAtividades] = useState('');
            const gutatividadesApi = new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("gutmatriz") > 0) {
  gutmatrizApi
    .getById(getParamFromUrl("gutmatriz"))
    .then((response) => {
      setNomeGUTMatriz(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutatividadesmatrizData.id === 0) {
    gutatividadesmatrizData.gutmatriz = getParamFromUrl("gutmatriz");
  }
}
 
if (getParamFromUrl("gutatividades") > 0) {
  gutatividadesApi
    .getById(getParamFromUrl("gutatividades"))
    .then((response) => {
      setNomeGUTAtividades(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutatividadesmatrizData.id === 0) {
    gutatividadesmatrizData.gutatividade = getParamFromUrl("gutatividades");
  }
}
 const addValorGUTMatriz = (e: any) => {
                        if (e?.id>0)
                        gutatividadesmatrizData.gutmatriz = e.id;
                      };
 const addValorGUTAtividade = (e: any) => {
                        if (e?.id>0)
                        gutatividadesmatrizData.gutatividade = e.id;
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
  {nomeGUTMatriz && (<h2>{nomeGUTMatriz}</h2>)}
{nomeGUTAtividades && (<h2>{nomeGUTAtividades}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <GUTMatrizComboBox
            name={'gutmatriz'}
            value={gutatividadesmatrizData.gutmatriz}
            setValue={addValorGUTMatriz}
            label={'G U T Matriz'}
            />

            <GUTAtividadesComboBox
            name={'gutatividade'}
            value={gutatividadesmatrizData.gutatividade}
            setValue={addValorGUTAtividade}
            label={'G U T Atividades'}
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
 