// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ILivroCaixa } from "../../Interfaces/interface.LivroCaixa";
import { LivroCaixaService } from "../../Services/LivroCaixa.service";
import { LivroCaixaApi } from "../../Apis/ApiLivroCaixa";
import LivroCaixaWindow from "./LivroCaixaWindow";

interface LivroCaixaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const LivroCaixaWindowId: React.FC<LivroCaixaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const livrocaixaService = useMemo(() => {
        return new LivroCaixaService(
            new LivroCaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ILivroCaixa | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await livrocaixaService.fetchLivroCaixaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <LivroCaixaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedLivroCaixa={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default LivroCaixaWindowId;