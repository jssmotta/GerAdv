//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ReuniaoEmpty } from "../../../Models/Reuniao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ReuniaoInc from "../Inc/Reuniao";
import { IReuniao } from "../../Interfaces/interface.Reuniao";
import { ReuniaoService } from "../../Services/Reuniao.service";
import { ReuniaoApi } from "../../Apis/ApiReuniao";
import { ReuniaoGridMobileComponent } from "../GridsMobile/Reuniao";
import { ReuniaoGridDesktopComponent } from "../GridsDesktop/Reuniao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterReuniao } from "../../Filters/Reuniao";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ReuniaoWindow from "./ReuniaoWindow";

const ReuniaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [reuniao, setReuniao] = useState<IReuniao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedReuniao, setSelectedReuniao] = useState<IReuniao>(ReuniaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterReuniao | undefined | null>(null);

    const reuniaoService = useMemo(() => {
      return new ReuniaoService(
          new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchReuniao = async (filtro?: FilterReuniao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await reuniaoService.getAll(filtro ?? {} as FilterReuniao);
        setReuniao(data);
      }
      else {
        const data = await reuniaoService.getAll(filtro ?? {} as FilterReuniao);
        setReuniao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchReuniao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (reuniao: IReuniao) => {
      if (isMobile) {
        router.push(`/pages/reuniao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${reuniao.id}`);
      } else {
        setSelectedReuniao(reuniao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/reuniao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedReuniao(ReuniaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchReuniao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const reuniao = e.dataItem;		
        setDeleteId(reuniao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchReuniao(currFilter);
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
            
        {isMobile ?
           <ReuniaoGridMobileComponent data={reuniao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ReuniaoGridDesktopComponent data={reuniao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ReuniaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedReuniao={selectedReuniao}>       
        </ReuniaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ReuniaoGrid;