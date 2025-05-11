// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IBensMateriais } from "../../Interfaces/interface.BensMateriais";
import { BensMateriaisService } from "../../Services/BensMateriais.service";
import { BensMateriaisApi } from "../../Apis/ApiBensMateriais";
import BensMateriaisWindow from "./BensMateriaisWindow";

interface BensMateriaisWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const BensMateriaisWindowId: React.FC<BensMateriaisWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const bensmateriaisService = useMemo(() => {
        return new BensMateriaisService(
            new BensMateriaisApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IBensMateriais | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await bensmateriaisService.fetchBensMateriaisById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <BensMateriaisWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedBensMateriais={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default BensMateriaisWindowId;