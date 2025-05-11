// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IUF } from "../../Interfaces/interface.UF";
import { UFService } from "../../Services/UF.service";
import { UFApi } from "../../Apis/ApiUF";
import UFWindow from "./UFWindow";

interface UFWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const UFWindowId: React.FC<UFWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const ufService = useMemo(() => {
        return new UFService(
            new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IUF | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await ufService.fetchUFById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <UFWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedUF={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default UFWindowId;