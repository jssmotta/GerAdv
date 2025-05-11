// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ILigacoes } from "../../Interfaces/interface.Ligacoes";
import { LigacoesService } from "../../Services/Ligacoes.service";
import { LigacoesApi } from "../../Apis/ApiLigacoes";
import LigacoesWindow from "./LigacoesWindow";

interface LigacoesWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const LigacoesWindowId: React.FC<LigacoesWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const ligacoesService = useMemo(() => {
        return new LigacoesService(
            new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ILigacoes | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await ligacoesService.fetchLigacoesById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <LigacoesWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedLigacoes={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default LigacoesWindowId;