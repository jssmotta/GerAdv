// useGridSort.tsx
"use client";
import { useState, useMemo } from 'react';
import { GridSortChangeEvent } from '@progress/kendo-react-grid';
import { sortData } from '@/app/tools/crud';

interface UseGridSortProps<T> {
  data: T[];
  customSortFunction?: (data: T[], sortDescriptor: any[]) => T[];
}

interface UseGridSortReturn<T> {
  sort: any[];
  sortedData: T[];
  handleSortChange: (e: GridSortChangeEvent) => void;
  setSort: React.Dispatch<React.SetStateAction<any[]>>;
}

export const useGridSort = <T,>({
  data,
  customSortFunction,
}: UseGridSortProps<T>): UseGridSortReturn<T> => {
  const [sort, setSort] = useState<any[]>([]);

  const sortedData = useMemo(() => {
    // Use custom sort function if provided, otherwise use default
    const sortFunction = customSortFunction || sortData;
    return sortFunction(data, sort);
  }, [data, sort, customSortFunction]);

  const handleSortChange = (e: GridSortChangeEvent) => {
    setSort(e.sort);
  };

  return {
    sort,
    sortedData,
    handleSortChange,
    setSort,
  };
};