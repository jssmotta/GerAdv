// DocumentosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { DocumentosGridAdapter } from '@/app/GerAdv_TS/Documentos/Adapter/DocumentosGridAdapter';
// Mock DocumentosGrid component
jest.mock('@/app/GerAdv_TS/Documentos/Crud/Grids/DocumentosGrid', () => () => <div data-testid='documentos-grid-mock' />);
describe('DocumentosGridAdapter', () => {
  it('should render DocumentosGrid component', () => {
    const adapter = new DocumentosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('documentos-grid-mock')).toBeInTheDocument();
  });
});