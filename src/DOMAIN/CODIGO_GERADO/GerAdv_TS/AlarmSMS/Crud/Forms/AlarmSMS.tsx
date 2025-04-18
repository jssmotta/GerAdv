﻿"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAlarmSMS } from '../../Interfaces/interface.AlarmSMS';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import RecadosComboBox from '@/app/GerAdv_TS/Recados/ComboBox/Recados';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import { RecadosApi } from '@/app/GerAdv_TS/Recados/Apis/ApiRecados';

interface AlarmSMSFormProps {
    alarmsmsData: IAlarmSMS;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AlarmSMSForm: React.FC<AlarmSMSFormProps> = ({
    alarmsmsData,
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
const [nomeAgenda, setNomeAgenda] = useState('');
            const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeRecados, setNomeRecados] = useState('');
            const recadosApi = new RecadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (alarmsmsData.id === 0) {
    alarmsmsData.operador = getParamFromUrl("operador");
  }
}
 
if (getParamFromUrl("agenda") > 0) {
  agendaApi
    .getById(getParamFromUrl("agenda"))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (alarmsmsData.id === 0) {
    alarmsmsData.agenda = getParamFromUrl("agenda");
  }
}
 
if (getParamFromUrl("recados") > 0) {
  recadosApi
    .getById(getParamFromUrl("recados"))
    .then((response) => {
      setNomeRecados(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (alarmsmsData.id === 0) {
    alarmsmsData.recado = getParamFromUrl("recados");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        alarmsmsData.operador = e.id;
                      };
 const addValorAgenda = (e: any) => {
                        if (e?.id>0)
                        alarmsmsData.agenda = e.id;
                      };
 const addValorRecado = (e: any) => {
                        if (e?.id>0)
                        alarmsmsData.recado = e.id;
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
{nomeAgenda && (<h2>{nomeAgenda}</h2>)}
{nomeRecados && (<h2>{nomeRecados}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={alarmsmsData.descricao}
            onChange={onChange}
            required
          />

<Input
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={alarmsmsData.hora}
onChange={onChange}               
/>

<Input
type="text"
id="minuto"
label="Minuto"
className="inputIncNome"
name="minuto"
value={alarmsmsData.minuto}
onChange={onChange}               
/>

<Checkbox label="D1" name="d1" checked={alarmsmsData.d1} onChange={onChange} />
<Checkbox label="D2" name="d2" checked={alarmsmsData.d2} onChange={onChange} />
<Checkbox label="D3" name="d3" checked={alarmsmsData.d3} onChange={onChange} />
<Checkbox label="D4" name="d4" checked={alarmsmsData.d4} onChange={onChange} />
<Checkbox label="D5" name="d5" checked={alarmsmsData.d5} onChange={onChange} />
<Checkbox label="D6" name="d6" checked={alarmsmsData.d6} onChange={onChange} />
<Checkbox label="D7" name="d7" checked={alarmsmsData.d7} onChange={onChange} />
</div><div className="grid-container">        
<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={alarmsmsData.email}
onChange={onChange}               
/>

<Checkbox label="Desativar" name="desativar" checked={alarmsmsData.desativar} onChange={onChange} />
        
<Input
type="text"
id="today"
label="Today"
className="inputIncNome"
name="today"
value={alarmsmsData.today}
onChange={onChange}               
/>

<Checkbox label="ExcetoDiasFelizes" name="excetodiasfelizes" checked={alarmsmsData.excetodiasfelizes} onChange={onChange} />
<Checkbox label="Desktop" name="desktop" checked={alarmsmsData.desktop} onChange={onChange} />
        
<Input
type="text"
id="alertardatahora"
label="AlertarDataHora"
className="inputIncNome"
name="alertardatahora"
value={alarmsmsData.alertardatahora}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={alarmsmsData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <AgendaComboBox
            name={'agenda'}
            value={alarmsmsData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

            <RecadosComboBox
            name={'recado'}
            value={alarmsmsData.recado}
            setValue={addValorRecado}
            label={'Recados'}
            />

<Input
type="text"
id="emocao"
label="Emocao"
className="inputIncNome"
name="emocao"
value={alarmsmsData.emocao}
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
 