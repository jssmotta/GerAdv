//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AcaoEmpty } from "../../../Models/Acao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AcaoInc from "../Inc/Acao";
import { IAcao } from "../../Interfaces/interface.Acao";
import { AcaoService } from "../../Services/Acao.service";
import { AcaoApi } from "../../Apis/ApiAcao";
import { AcaoGridMobileComponent } from "../GridsMobile/Acao";
import { AcaoGridDesktopComponent } from "../GridsDesktop/Acao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAcao } from "../../Filters/Acao";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AcaoWindow from "./AcaoWindow";

const AcaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [acao, setAcao] = useState<IAcao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAcao, setSelectedAcao] = useState<IAcao>(AcaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAcao | undefined | null>(null);

    const acaoService = useMemo(() => {
      return new AcaoService(
          new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAcao = async (filtro?: FilterAcao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await acaoService.getList(filtro ?? {} as FilterAcao);
        setAcao(data);
      }
      else {
        const data = await acaoService.getAll(filtro ?? {} as FilterAcao);
        setAcao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAcao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (acao: IAcao) => {
      if (isMobile) {
        router.push(`/pages/acao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${acao.id}`);
      } else {
        setSelectedAcao(acao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/acao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAcao(AcaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAcao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const acao = e.dataItem;		
        setDeleteId(acao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAcao(currFilter);
            } catch {
            // falta uma mensagem de erro
            } finally {
            setDeleteId(null);
                setIsModalOpen(false);
            }
        }
    };
      
    const cancelDelete = () => {
        setDeleteId(null);
        setIsModalOpen(false);
    };

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <AcaoGridMobileComponent data={acao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AcaoGridDesktopComponent data={acao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AcaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAcao={selectedAcao}>       
        </AcaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AcaoGrid;