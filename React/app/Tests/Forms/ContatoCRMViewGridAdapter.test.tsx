// ContatoCRMViewGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ContatoCRMViewGridAdapter } from '@/app/GerAdv_TS/ContatoCRMView/Adapter/ContatoCRMViewGridAdapter';
// Mock ContatoCRMViewGrid component
jest.mock('@/app/GerAdv_TS/ContatoCRMView/Crud/Grids/ContatoCRMViewGrid', () => () => <div data-testid='contatocrmview-grid-mock' />);
describe('ContatoCRMViewGridAdapter', () => {
  it('should render ContatoCRMViewGrid component', () => {
    const adapter = new ContatoCRMViewGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('contatocrmview-grid-mock')).toBeInTheDocument();
  });
});